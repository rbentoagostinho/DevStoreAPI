using Ambev.DeveloperEvaluation.WebApi.Models;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, length between 3 and 100 characters
    /// - Description: Required, length up to 500 characters
    /// - Price: Must be a positive value
    /// - Category: Required, length up to 50 characters
    /// - Image: Required, must be a valid URL, length up to 200 characters
    /// - Rating: Must have valid Rate and Count
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters");

        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Price must be a positive value");

        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters");

        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Image is required")
            .MaximumLength(200).WithMessage("Image URL cannot be longer than 200 characters")
            .Must(BeAValidUrl).WithMessage("Image must be a valid URL");

        RuleFor(product => product.Rating).SetValidator(new RatingRequestValidator());
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}

/// <summary>
/// Validator for RatingRequest that defines validation rules for product rating.
/// </summary>
public class RatingRequestValidator : AbstractValidator<RatingRequest>
{
    /// <summary>
    /// Initializes a new instance of the RatingRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Rate: Must be between 0 and 5
    /// - Count: Must be a non-negative integer
    /// </remarks>
    public RatingRequestValidator()
    {
        RuleFor(rating => rating.Rate).InclusiveBetween(0, 5);
        RuleFor(rating => rating.Count).GreaterThanOrEqualTo(0);
    }
}




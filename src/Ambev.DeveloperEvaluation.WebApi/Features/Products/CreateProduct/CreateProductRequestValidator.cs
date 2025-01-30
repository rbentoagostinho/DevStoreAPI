using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .Length(3, 100)
            .WithMessage("Title must be between 3 and 100 characters");

        RuleFor(product => product.Description)
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters");

        RuleFor(product => product.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");

        RuleFor(product => product.Category)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Category is required and cannot exceed 50 characters");

        RuleFor(product => product.Image)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(product => !string.IsNullOrEmpty(product.Image))
            .WithMessage("Image must be a valid URL");

        RuleFor(product => product.RateValue)
            .InclusiveBetween(0, 5)
            .WithMessage("Rate value must be between 0 and 5");

        RuleFor(product => product.RateCount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Rate count must be greater than or equal to 0");
    }
}
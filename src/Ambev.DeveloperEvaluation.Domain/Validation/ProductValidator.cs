using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Title must not be empty.")
            .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Price must be a positive value.");

        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category must not be empty.");

        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Image URL must not be empty.")
            .Must(BeAValidUrl).WithMessage("Image URL must be a valid URL.");

        RuleFor(product => product.Rating.Rate)
            .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

        RuleFor(product => product.Rating.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Rating count must be a non-negative integer.");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}


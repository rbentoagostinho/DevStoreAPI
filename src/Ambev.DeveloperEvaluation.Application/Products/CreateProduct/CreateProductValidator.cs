using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes validation rules for CreateProductCommand
    /// </summary>
    public CreateProductValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be a positive value");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters");

        RuleFor(x => x.Image)
            .MaximumLength(200).WithMessage("Image URL cannot be longer than 200 characters");
    }
}











using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemCommand.
/// </summary>
public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for CreateSaleItemCommand.
    /// </summary>
    public CreateSaleItemValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required.");

        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Product name is required.")
            .MaximumLength(100)
            .WithMessage("Product name must not exceed 100 characters.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Unit price must be greater than 0.");
    }
}
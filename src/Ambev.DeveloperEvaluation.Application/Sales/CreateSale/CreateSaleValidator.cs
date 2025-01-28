using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for CreateSaleCommand.
    /// </summary>
    public CreateSaleValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("Sale number is required.")
            .MaximumLength(50)
            .WithMessage("Sale number must not exceed 50 characters.");

        RuleFor(x => x.SaleDate)
            .NotEmpty()
            .WithMessage("Sale date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Sale date cannot be in the future.");

        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(x => x.Branch)
            .NotEmpty()
            .WithMessage("Branch is required.")
            .MaximumLength(100)
            .WithMessage("Branch must not exceed 100 characters.");

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("At least one item is required.");

        RuleForEach(x => x.Items)
            .SetValidator(new SaleItemValidator());
    }
}

/// <summary>
/// Validator for SaleItemDto.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItemDto>
{
    /// <summary>
    /// Initializes validation rules for SaleItemDto.
    /// </summary>
    public SaleItemValidator()
    {
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
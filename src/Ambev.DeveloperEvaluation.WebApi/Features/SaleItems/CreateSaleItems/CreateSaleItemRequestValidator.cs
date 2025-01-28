using Ambev.DeveloperEvaluation.WebApi.Models;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItems;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
/// <summary>
/// Validator for CreateSaleItemRequest
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required");
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0");
    }
}



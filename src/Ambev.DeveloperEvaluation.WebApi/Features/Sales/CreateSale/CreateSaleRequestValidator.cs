using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(3, 20);
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 50);
        RuleForEach(sale => sale.Items).SetValidator(new SaleItemValidator());
    }
}
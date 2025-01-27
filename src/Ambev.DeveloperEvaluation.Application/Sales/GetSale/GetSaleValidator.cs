using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class GetSaleItemValidator : AbstractValidator<GetSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public GetSaleItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product ID is required");
    }
}












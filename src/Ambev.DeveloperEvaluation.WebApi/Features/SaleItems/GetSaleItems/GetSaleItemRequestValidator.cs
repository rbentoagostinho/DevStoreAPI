using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItems;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItems;

/// <summary>
/// Validator for GetSaleItemRequest
/// </summary>
public class GetSaleItemRequestValidator : AbstractValidator<GetSaleItemRequest>
{
    public GetSaleItemRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale item ID is required");
    }
}



using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Validator for GetProductsRequest that defines validation rules for getting a product
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the GetProductsRequestValidator with defined validation rules.
    /// </summary>
    public GetSaleRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithMessage("Product ID is required");
    }
}




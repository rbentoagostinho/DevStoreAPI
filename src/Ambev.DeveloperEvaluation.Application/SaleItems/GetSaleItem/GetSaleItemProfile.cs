using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Mapping profile for GetProductCommand and GetProductResult
/// </summary>
public class GetSaleItemProfile : Profile
{
    public GetSaleItemProfile()
    {
        CreateMap<Product, GetSaleItemResult>();
    }
}












using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Mapping profile for CreateProductCommand and CreateProductResult
/// </summary>
public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, Product>();
        CreateMap<Product, CreateSaleItemResult>();
    }
}











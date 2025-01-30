using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        // Mapeamento de GetProductRequest para GetProductCommand
        CreateMap<GetProductRequest, GetProductCommand>()
            .ConstructUsing(src => new GetProductCommand(src.Id));

        // Mapeamento de Product para GetProductResponse
        CreateMap<Product, GetProductResponse>();
    }
}
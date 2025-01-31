// CreateSaleProfile.cs
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        // Mapeamento da requisição para o comando
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<SaleItemRequest, SaleItemCommand>();

        // Mapeamento do resultado para a resposta
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<CreateSaleResult.SaleItemResult, CreateSaleItemResponse>();
    }
}
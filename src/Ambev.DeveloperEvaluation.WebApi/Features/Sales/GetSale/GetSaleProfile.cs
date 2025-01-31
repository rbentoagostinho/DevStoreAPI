// Features/Sales/GetSale/GetSaleProfile.cs
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleCommand>()
            .ConstructUsing(src => new GetSaleCommand(src.Id));

        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleResult.SaleItemResult, GetSaleItemResponse>();
    }
}
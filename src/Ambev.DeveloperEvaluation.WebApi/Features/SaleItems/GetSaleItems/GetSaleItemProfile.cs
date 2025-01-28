using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// Profile for mapping GetSaleItem feature requests to commands
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItem feature
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<Guid, GetSaleItemCommand>()
            .ConstructUsing(id => new GetSaleItemCommand(id));
    }
}


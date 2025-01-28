using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Profile for mapping CreateSaleItem feature requests to commands
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItem feature
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}
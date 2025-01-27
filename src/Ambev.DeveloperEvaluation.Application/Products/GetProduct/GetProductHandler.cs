using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Handler for GetProductCommand
/// </summary>
public class GetSaleItemHandler : IRequestHandler<GetSaleItemCommand, GetSaleItemResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetSaleItemHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleItemResult> Handle(GetSaleItemCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetSaleItemResult>(product);
    }
}












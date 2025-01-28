using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Handler for processing GetSaleItemCommand requests.
/// </summary>
public class GetSaleItemHandler : IRequestHandler<GetSaleItemCommand, GetSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleItemHandler.
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleItemCommand request.
    /// </summary>
    /// <param name="request">The GetSaleItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sale item details if found.</returns>
    public async Task<GetSaleItemResult> Handle(GetSaleItemCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new GetSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Retrieve the sale item from the repository
        var saleItem = await _saleItemRepository.GetByIdAsync(request.Id);

        if (saleItem == null)
            throw new KeyNotFoundException($"Sale item with ID {request.Id} not found.");

        // Map the sale item to the result
        var result = _mapper.Map<GetSaleItemResult>(saleItem);

        return result;
    }
}
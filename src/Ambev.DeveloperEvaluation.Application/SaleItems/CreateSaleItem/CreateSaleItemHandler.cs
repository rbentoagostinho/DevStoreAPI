using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSale;

/// <summary>
/// Handler for processing CreateSaleItemCommand requests.
/// </summary>
public class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleItemHandler.
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleItemCommand request.
    /// </summary>
    /// <param name="request">The CreateSaleItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created sale item details.</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new CreateSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Map the command to a SaleItem entity
        var saleItem = _mapper.Map<SaleItem>(request);

        // Calculate the total price of the item
        saleItem.CalculateTotalPrice();

        // Save the sale item to the database
        var createdSaleItem = await _saleItemRepository.CreateAsync(saleItem);

        // Map the result to a CreateSaleItemResult
        var result = _mapper.Map<CreateSaleItemResult>(createdSaleItem);

        return result;
    }
}
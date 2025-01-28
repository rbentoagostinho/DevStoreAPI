using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests.
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request.
    /// </summary>
    /// <param name="request">The CreateSale command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created sale details.</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Map the command to a Sale entity
        var sale = _mapper.Map<Sale>(request);

        // Calculate the total amount of the sale
        sale.CalculateTotalAmount();

        // Save the sale to the database
        var createdSale = await _saleRepository.CreateAsync(sale);

        // Map the result to a CreateSaleResult
        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
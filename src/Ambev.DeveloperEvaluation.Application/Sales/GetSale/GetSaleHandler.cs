﻿using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests.
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleCommand request.
    /// </summary>
    /// <param name="request">The GetSale command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sale details if found.</returns>
    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new GetSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Retrieve the sale from the repository
        var sale = await _saleRepository.GetByIdAsync(request.Id);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");

        // Map the sale to the result
        var result = _mapper.Map<GetSaleResult>(sale);

        return result;
    }
}
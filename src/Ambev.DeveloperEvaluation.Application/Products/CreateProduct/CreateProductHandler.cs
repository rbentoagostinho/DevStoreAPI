﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Product>(command);
        var createdProduct = await _productRepository.CreateAsync(product);

        // Corrigido para mapear para CreateProductResult
        return _mapper.Map<CreateProductResult>(createdProduct);
    }
}

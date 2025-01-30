using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Command for retrieving a product by its ID
/// </summary>

public class GetProductCommand : IRequest<Product>
{
    public Guid Id { get; }

    public GetProductCommand(Guid id)
    {
        Id = id;
    }
}
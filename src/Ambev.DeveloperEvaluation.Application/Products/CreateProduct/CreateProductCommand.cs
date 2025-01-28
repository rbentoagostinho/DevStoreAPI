using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product
/// </summary>
public record CreateProductCommand : IRequest<CreateProductResult>
{
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
}











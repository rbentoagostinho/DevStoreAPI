using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Command for deleting a product
/// </summary>
public record DeleteProductCommand : IRequest<DeleteProductResponse>
{
    /// <summary>
    /// The unique identifier of the product to delete
    /// </summary>
    public Guid ProductId { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProductCommand
    /// </summary>
    /// <param name="productId">The ID of the product to delete</param>
    public DeleteProductCommand(Guid productId)
    {
        ProductId = productId;
    }
}

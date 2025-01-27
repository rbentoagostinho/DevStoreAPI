using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Command for getting a product
/// </summary>
public record GetSaleItemCommand : IRequest<GetSaleItemResult>
{
    /// <summary>
    /// The unique identifier of the product to get
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Initializes a new instance of GetProductCommand
    /// </summary>
    /// <param name="id">The ID of the product to get</param>
    public GetSaleItemCommand(Guid id)
    {
        Id = id;
    }
}












using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Command for retrieving a sale item by its ID.
/// </summary>
public class GetSaleItemCommand : IRequest<GetSaleItemResult>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale item to retrieve.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleItemCommand.
    /// </summary>
    /// <param name="id">The ID of the sale item to retrieve.</param>
    public GetSaleItemCommand(Guid id)
    {
        Id = id;
    }
}
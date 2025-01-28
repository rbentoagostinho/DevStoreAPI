namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Request model for creating a sale item
/// </summary>
public class CreateSaleItemRequest
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

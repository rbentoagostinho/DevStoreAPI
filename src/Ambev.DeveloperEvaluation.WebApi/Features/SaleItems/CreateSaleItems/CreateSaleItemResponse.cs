
namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <summary>
/// Response model for creating a sale item
/// </summary>
public class CreateSaleItemResponse
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}

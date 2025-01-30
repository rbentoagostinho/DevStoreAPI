using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItems;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// The date of the sale
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The customer's unique identifier
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The customer's name
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// The total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The branch where the sale occurred
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The list of items in the sale
    /// </summary>
    /// 

    public List<GetSaleItemResponse> Items { get; set; } = new List<GetSaleItemResponse>();

    /// <summary>
    /// Indicates whether the sale is cancelled
    /// </summary>
    public bool IsCancelled { get; set; }
}
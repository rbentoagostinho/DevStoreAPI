namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItems;

    /// <summary>
    /// Response model for getting a product
    /// </summary>
    /// <summary>
    /// API response model for GetSaleItem operation
    /// </summary>
    public class GetSaleItemResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
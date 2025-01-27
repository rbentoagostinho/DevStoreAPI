namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Result model for GetProduct operation
/// </summary>
public class GetSaleItemResult
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
}












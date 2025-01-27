namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Result model for CreateProduct operation
/// </summary>
public class CreateSaleItemResult
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
}











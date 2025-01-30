using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// API response model for GetProduct operation
/// </summary>
public class GetProductResponse
{
    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The product description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The product price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The product category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The product image URL
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// The product rating information
    /// </summary>
    public Rating Rating { get; set; } = new Rating();

    /// <summary>
    /// The date when the product was created
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
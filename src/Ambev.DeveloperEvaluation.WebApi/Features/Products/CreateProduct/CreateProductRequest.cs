namespace Ambev.DeveloperEvaluation.WebApi.Models;

/// <summary>
/// Represents the request to create a new product.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the product title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the product category.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product image URL.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product rating.
    /// </summary>
    public RatingRequest Rating { get; set; } = new RatingRequest();
}

/// <summary>
/// Represents the rating of a product in the create request.
/// </summary>
public class RatingRequest
{
    /// <summary>
    /// Gets or sets the rating value.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets or sets the count of ratings.
    /// </summary>
    public int Count { get; set; }
}


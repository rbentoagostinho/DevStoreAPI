/// <summary>
/// Represents the rating of a product.
/// </summary>
public class Rating
{
    /// <summary>
    /// Gets or sets the rating ID.
    /// </summary>
    public int Id { get; set; } // Chave primária

    /// <summary>
    /// Gets or sets the rating value.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets or sets the count of ratings.
    /// </summary>
    public int Count { get; set; }
}
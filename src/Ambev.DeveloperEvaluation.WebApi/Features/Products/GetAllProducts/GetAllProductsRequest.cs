namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsRequest
{
    /// <summary>
    /// The page number (1-based)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// The number of items per page
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// The ordering criteria
    /// </summary>
    public string Order { get; set; } = string.Empty;
}
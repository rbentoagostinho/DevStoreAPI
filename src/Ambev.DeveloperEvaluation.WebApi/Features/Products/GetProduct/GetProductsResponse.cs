namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Response model for getting a product
    /// </summary>
    public class GetProductsResponse
    {
        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the product
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The description of the product
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The category of the product
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The image URL of the product
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// The rating of the product
        /// </summary>
        public GetProductRatingResponse Rating { get; set; } = new GetProductRatingResponse();
    }

    /// <summary>
    /// Represents the rating of a product in the response
    /// </summary>
    public class GetProductRatingResponse
    {
        /// <summary>
        /// The rating value
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The count of ratings
        /// </summary>
        public int Count { get; set; }
    }
}

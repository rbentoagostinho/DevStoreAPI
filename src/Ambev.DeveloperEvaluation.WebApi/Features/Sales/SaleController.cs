using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing product operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of ProductsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="productRepository">The product repository instance</param>
    public ProductsController(IMediator mediator, IMapper mapper, IProductRepository productRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="request">The product creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a product by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Product not found"
            });
        }

        var response = _mapper.Map<GetSaleResponse>(product);
        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = response
        });
    }

    /// <summary>
    /// Retrieves a list of products with pagination and sorting
    /// </summary>
    /// <param name="_page">Page number for pagination</param>
    /// <param name="_size">Number of items per page</param>
    /// <param name="_order">Ordering of results (e.g., "price desc, title asc")</param>
    /// <returns>A paginated list of products</returns>
    [HttpGet("all")]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<GetSaleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken, [FromQuery] int _page = 1, [FromQuery] int _size = 10, [FromQuery] string _order = "")
    {
        var products = await _productRepository.GetAllAsync(_page, _size, _order, cancellationToken);
        var response = _mapper.Map<IEnumerable<GetSaleResponse>>(products);
        return Ok(new ApiResponseWithData<IEnumerable<GetSaleResponse>>
        {
            Success = true,
            Message = "Products retrieved successfully",
            Data = response
        });
    }






    /// <summary>
    /// Deletes a product by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the product was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Product not found"
            });
        }

        await _productRepository.DeleteAsync(id);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }
}




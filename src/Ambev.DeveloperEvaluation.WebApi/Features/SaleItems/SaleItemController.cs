using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

/// <summary>
/// Controller for managing sale items
/// </summary>
[ApiController]
[Route("api/sale-items")]
public class SaleItemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItemController"/> class.
    /// </summary>
    public SaleItemController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new sale item
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request)
    {
        var command = _mapper.Map<CreateSaleItemCommand>(request);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetSaleItem), new { id = result.Id }, result);
    }

    /// <summary>
    /// Gets a sale item by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaleItem(Guid id)
    {
        var command = new GetSaleItemCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

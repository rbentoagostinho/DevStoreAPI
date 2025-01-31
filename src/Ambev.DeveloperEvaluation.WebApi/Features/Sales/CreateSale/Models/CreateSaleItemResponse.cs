// Features/Sales/CreateSale/Models/CreateSaleItemResponse.cs
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.Models;

/// <summary>
/// Representa a resposta de um item em uma nova venda
/// </summary>
public class CreateSaleItemResponse
{
    /// <summary>
    /// Identificador único do item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador do produto
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantidade vendida
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Preço unitário
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Desconto aplicado
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Valor total do item
    /// </summary>
    public decimal TotalAmount { get; set; }
}
// Features/Sales/GetSale/Models/GetSaleItemResponse.cs
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale.Models;

/// <summary>
/// Representa um item de venda na consulta
/// </summary>
public class GetSaleItemResponse
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
    /// Nome do produto
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

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
// Domain/Entities/SaleItem.cs
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    /// <summary>
    /// ID da venda relacionada
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Produto vendido
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// ID do produto
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantidade vendida
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Preço unitário no momento da venda
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Desconto aplicado ao item
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Valor total do item (Quantidade * Preço Unitário - Desconto)
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Venda relacionada
    /// </summary>
    public Sale Sale { get; set; } = null!;
}
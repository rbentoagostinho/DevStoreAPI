// Features/Sales/CreateSale/CreateSaleResponse.cs
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Representa a resposta de criação de uma nova venda
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// Identificador único da venda
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Número da venda
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Data da venda
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Nome da filial
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Valor total da venda
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Indica se a venda está cancelada
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Itens da venda
    /// </summary>
    public List<CreateSaleItemResponse> Items { get; set; } = new();
}
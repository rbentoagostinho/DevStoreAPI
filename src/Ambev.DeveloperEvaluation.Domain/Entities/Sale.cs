// Domain/Entities/Sale.cs
using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    /// <summary>
    /// Número único da venda
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Data da realização da venda
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Cliente que realizou a compra
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Filial onde a venda foi realizada
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Valor total da venda
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Status de cancelamento da venda
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Itens da venda
    /// </summary>
    public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();

    /// <summary>
    /// Data de criação do registro
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Data da última atualização
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
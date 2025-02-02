// Domain/Entities/Sale.cs
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Identity;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Representa uma venda no sistema com produtos e informa��es de pagamento.
/// Esta entidade segue os princ�pios do DDD e inclui valida��o de regras de neg�cio.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// N�mero �nico da venda
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Data da realiza��o da venda
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
    /// Data de cria��o do registro
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Data da �ltima atualiza��o
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Inicializa uma nova inst�ncia da classe Sale.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Realiza a valida��o da entidade venda usando as regras do SaleValidator.
    /// </summary>
    /// <returns>
    /// Um <see cref="ValidationResultDetail"/> contendo:
    /// - IsValid: Indica se todas as regras de valida��o passaram
    /// - Errors: Cole��o de erros de valida��o caso alguma regra falhe
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => new ValidationErrorDetail
            {
                Error = o.ErrorMessage,
                Detail = o.PropertyName
            })
        };
    }

    /// <summary>
    /// Cancela a venda.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Calcula o total da venda baseado nos itens.
    /// </summary>
    public void CalculateTotal()
    {
        TotalAmount = Items.Sum(item => item.TotalAmount);
    }
}
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sale.
/// </summary>
public class SaleItem : BaseEntity
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty; // Desnormalização de descrições de entidades
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Calculates the total price of the item based on the quantity and unit price, applying discounts if applicable.
    /// </summary>
    public void CalculateTotalPrice()
    {
        if (Quantity > 20)
        {
            throw new InvalidOperationException("Não é possível vender acima de 20 itens idênticos.");
        }
        else if (Quantity >= 10)
        {
            Discount = 0.20m;
        }
        else if (Quantity > 4)
        {
            Discount = 0.10m;
        }
        else
        {
            Discount = 0.00m;
        }

        TotalPrice = Quantity * UnitPrice * (1 - Discount);
    }

    /// <summary>
    /// Performs validation of the sale item entity using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Product ID</list>
    /// <list type="bullet">Product name format and length</list>
    /// <list type="bullet">Quantity value</list>
    /// <list type="bullet">Unit price value</list>
    /// <list type="bullet">Total price value</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}



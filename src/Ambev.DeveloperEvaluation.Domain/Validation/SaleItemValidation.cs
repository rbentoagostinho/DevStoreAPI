// Domain/Validation/SaleItemValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validador para a entidade SaleItem que define regras de validação para itens de venda.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItem>
{
    private const int MIN_ITEMS_FOR_FIRST_DISCOUNT = 4;
    private const int MIN_ITEMS_FOR_SECOND_DISCOUNT = 10;
    private const int MAX_ITEMS_ALLOWED = 20;
    private const decimal FIRST_DISCOUNT_PERCENTAGE = 0.10m;
    private const decimal SECOND_DISCOUNT_PERCENTAGE = 0.20m;

    public SaleItemValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty()
            .WithMessage("O ID do produto é obrigatório.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .LessThanOrEqualTo(MAX_ITEMS_ALLOWED)
            .WithMessage($"A quantidade deve estar entre 1 e {MAX_ITEMS_ALLOWED} itens.");

        RuleFor(item => item)
            .Must(ValidateDiscount)
            .WithMessage(item => GetDiscountValidationMessage(item));

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0)
            .WithMessage("O preço unitário deve ser maior que zero.");
    }

    private bool ValidateDiscount(SaleItem item)
    {
        var maxDiscount = CalculateMaxDiscount(item);

        if (item.Quantity < MIN_ITEMS_FOR_FIRST_DISCOUNT && item.Discount > 0)
            return false;

        return item.Discount <= maxDiscount;
    }

    private string GetDiscountValidationMessage(SaleItem item)
    {
        if (item.Quantity < MIN_ITEMS_FOR_FIRST_DISCOUNT && item.Discount > 0)
            return $"Não é permitido desconto para compras com menos de {MIN_ITEMS_FOR_FIRST_DISCOUNT} itens.";

        var maxDiscount = CalculateMaxDiscount(item);
        return $"O desconto máximo permitido para {item.Quantity} itens é de {maxDiscount:C2}.";
    }

    private decimal CalculateMaxDiscount(SaleItem item)
    {
        var baseValue = item.Quantity * item.UnitPrice;

        if (item.Quantity < MIN_ITEMS_FOR_FIRST_DISCOUNT)
            return 0;

        if (item.Quantity >= MIN_ITEMS_FOR_SECOND_DISCOUNT)
            return baseValue * SECOND_DISCOUNT_PERCENTAGE;

        return baseValue * FIRST_DISCOUNT_PERCENTAGE;
    }
}
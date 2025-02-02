using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validador para a entidade Sale que define regras de validação para vendas.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.CustomerName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("O nome do cliente é obrigatório e não pode exceder 100 caracteres.");

        RuleFor(sale => sale.BranchName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("O nome da filial é obrigatório e não pode exceder 100 caracteres.");

        RuleFor(sale => sale.Items)
            .NotEmpty()
            .WithMessage("A venda deve conter pelo menos um item.");

        RuleForEach(sale => sale.Items)
            .SetValidator(new SaleItemValidator());

        RuleFor(sale => sale.TotalAmount)
            .GreaterThan(0)
            .WithMessage("O valor total da venda deve ser maior que zero.");

        RuleFor(sale => sale)
            .Must(sale => !sale.Items.GroupBy(i => i.ProductId).Any(g => g.Count() > 1))
            .WithMessage("Não é permitido adicionar o mesmo produto mais de uma vez. Por favor, ajuste a quantidade.");
    }
}
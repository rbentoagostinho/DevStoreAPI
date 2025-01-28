﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Validator for GetSaleItemCommand.
/// </summary>
public class GetSaleItemValidator : AbstractValidator<GetSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemCommand.
    /// </summary>
    public GetSaleItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale item ID is required.");
    }
}
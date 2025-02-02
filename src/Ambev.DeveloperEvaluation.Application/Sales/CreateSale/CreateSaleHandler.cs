// Application/Sales/CreateSale/CreateSaleHandler.cs
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        // 1. Validação do comando
        var commandValidator = new CreateSaleValidator();
        var commandValidationResult = await commandValidator.ValidateAsync(command, cancellationToken);

        if (!commandValidationResult.IsValid)
            throw new ValidationException(commandValidationResult.Errors);

        // 2. Criação da entidade Sale e seus itens
        var sale = new Sale
        {
            CustomerName = command.CustomerName,
            BranchName = command.BranchName,
            SaleDate = DateTime.UtcNow
        };

        // 3. Criação e cálculo dos itens
        foreach (var itemCommand in command.Items)
        {
            var item = new SaleItem
            {
                ProductId = itemCommand.ProductId,
                Quantity = itemCommand.Quantity,
                UnitPrice = itemCommand.UnitPrice,
                Discount = itemCommand.Discount
            };

            // Calcula o total do item
            item.TotalAmount = (item.Quantity * item.UnitPrice) - item.Discount;
            sale.Items.Add(item);
        }

        // 4. Calcula o total da venda
        sale.TotalAmount = sale.Items.Sum(item => item.TotalAmount);

        // 5. Validação do domínio
        var domainValidationResult = sale.Validate();
        if (!domainValidationResult.IsValid)
        {
            throw new ValidationException(
                domainValidationResult.Errors
                    .Select(e => new ValidationFailure(e.Detail, e.Error))
                    .ToList()
            );
        }

        // 6. Persistência
        var createdSale = await _saleRepository.CreateAsync(sale);

        // 7. Retorno do resultado
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
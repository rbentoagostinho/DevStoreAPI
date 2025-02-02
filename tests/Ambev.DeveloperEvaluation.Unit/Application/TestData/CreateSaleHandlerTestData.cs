using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

public static class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.CustomerName, f => f.Person.FullName)
        .RuleFor(s => s.BranchName, f => f.Company.CompanyName())
        .RuleFor(s => s.Items, f => GenerateSaleItemCommands(f));

    private static List<SaleItemCommand> GenerateSaleItemCommands(Faker f)
    {
        var items = new List<SaleItemCommand>();
        var itemCount = f.Random.Number(1, 3);

        for (int i = 0; i < itemCount; i++)
        {
            var quantity = f.Random.Number(5, 15);
            var unitPrice = f.Random.Decimal(10, 1000);

            items.Add(new SaleItemCommand
            {
                ProductId = Guid.NewGuid(),
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = quantity >= 10 ? unitPrice * quantity * 0.20m : unitPrice * quantity * 0.10m
            });
        }

        return items;
    }

    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}
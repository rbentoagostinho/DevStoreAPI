using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class SaleTestData
{
    public static Sale GenerateSaleWithExcessiveQuantity()
    {
        var sale = new Sale
        {
            CustomerName = "Test Customer",
            BranchName = "Test Branch",
            SaleDate = DateTime.UtcNow,
            Items = new List<SaleItem>
            {
                new SaleItem // Item com quantidade excessiva
                {
                    ProductId = Guid.NewGuid(),
                    Quantity = 21, // Quantidade inválida
                    UnitPrice = 100,
                    Discount = 0,
                    TotalAmount = 2100
                }
            }
        };

        sale.TotalAmount = sale.Items.Sum(i => i.TotalAmount);
        return sale;
    }
}

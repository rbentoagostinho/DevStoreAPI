using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests{
    

    [Fact(DisplayName = "Excessive quantity should fail validation")]
    public void Given_SaleWithExcessiveQuantity_When_Validated_Then_ShouldBeInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithExcessiveQuantity();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors,
            e => e.Error.Contains("quantidade deve estar entre 1 e 20")); // Ajustando para a mensagem exata
    }

   
}
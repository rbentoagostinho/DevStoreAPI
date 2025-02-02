using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    [Fact(DisplayName = "Items with excessive quantity should fail validation")]
    public void Given_ItemWithExcessiveQuantity_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithExcessiveQuantity();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        // Primeiro, verificamos se há erros de validação
        result.ShouldHaveAnyValidationError();

        // Então verificamos especificamente os erros relacionados à quantidade
        result.Errors.Should().Contain(error =>
            error.PropertyName.Contains("Quantity") &&
            error.ErrorMessage.Contains("quantidade deve estar entre 1 e 20"));
    }
}
using CurrencyConverter.Controllers;
using CurrencyConverter.Services;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CurrencyConverter.UnitTest.APITests
{
    public class CurrencyControllerTests
    {
        [Fact]
        public void GetDollar_ShouldReturnBadRequest_WhenInputValueHasInvalidCharacter()
        {
            //Arrange
            var dollarConvertorMock = new Mock<DollarConvertor>();
            var convertorMock = new Mock<Convertor>();
            var currencyInputValidatorMock = new Mock<IValidator<string>>();

            var controller = new CurrencyController(
            dollarConvertorMock.Object,
            convertorMock.Object,
            currencyInputValidatorMock.Object
            );

            string invalidNumber = "InvalidNumber";

            //Act 
            var result = controller.GetDollar(invalidNumber);

            result.Should().BeOfType<BadRequestObjectResult>().Which.Value.Should().Be("Input string number should only contain numbers, spaces, and commas.");
            //Assert
        }

        [Fact]
        public void GetDollar_ShouldReturnBadRequest_WhenInputValueMoreThanNineNumberBeforeComma()
        {
        }

        [Fact]
        public void GetDollar_ShouldReturnBadRequest_WhenInputValueMoreThanTwoNumberAfterComma()
        {
        }
    }
}

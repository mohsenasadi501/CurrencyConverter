using CurrencyConverter.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly DollarConvertor _dollarConvertor;
        private readonly Convertor _convertor;
        private readonly IValidator<string> _currencyInputValidator;

        public CurrencyController(DollarConvertor dollarConvertor, Convertor convertor, IValidator<string> currencyInputValidator)
        {
            _dollarConvertor = dollarConvertor;
            _convertor = convertor;
            _currencyInputValidator = currencyInputValidator;
        }

        [HttpGet]
        public IActionResult GetDollar(string number)
        {
            var validationResult = _currencyInputValidator.Validate(number);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            string value = _convertor.Convert(number, _dollarConvertor);
            return Ok(value);
        }
    }
}

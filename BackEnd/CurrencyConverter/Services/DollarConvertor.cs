namespace CurrencyConverter.Services
{
    public class DollarConvertor : IConvertor
    {
        private readonly ILogger<DollarConvertor> _logger;
        private readonly NumberConverter _numberConverter;

        public DollarConvertor(ILogger<DollarConvertor> logger , NumberConverter numberConverter)
        {
            _logger = logger;
            _numberConverter = numberConverter;
        }

        public string DoConvert(string number)
        {
            try
            {
                string dollar;
                number = number.Replace(" ", "");
                if (number == "0")
                    return "zero dollars";

                if (number.Contains(','))
                {
                    string[] numberArray = number.Split(',');
                    dollar = _numberConverter.ConvertWord(numberArray[0]);
                    string cent = _numberConverter.ConvertWord(numberArray[1]);
                    if (cent == "1")
                        return dollar + " dollars and " + cent + " cent";
                    else
                        return dollar + " dollars and " + cent + " cents";
                }
                else
                {
                    dollar = _numberConverter.ConvertWord(number);
                    if (number == "1")
                        return dollar + " dollar";
                    else
                        return dollar + " dollars";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return string.Empty;
            }
        }
    }
}

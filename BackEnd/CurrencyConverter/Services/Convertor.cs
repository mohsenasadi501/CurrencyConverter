namespace CurrencyConverter.Services
{
    public class Convertor
    {
        public string Convert(string number, IConvertor convertor)
        {
            return convertor.DoConvert(number);
        }
    }
}

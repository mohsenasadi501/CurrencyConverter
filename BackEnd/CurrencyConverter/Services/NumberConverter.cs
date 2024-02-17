namespace CurrencyConverter.Services
{
    public class NumberConverter
    {

        Dictionary<int, string> OnesWords = new Dictionary<int, string>()
            {
                {0 , "zero" },
                {1 , "one" },
                {2 , "two" },
                {3 , "three" },
                {4 , "four" },
                {5 , "five" },
                {6 , "six" },
                {7 , "seven" },
                {8 , "eight" },
                {9 , "nine" },
            };
        Dictionary<int, string> TensWords = new Dictionary<int, string>()
            {
                {10 , "ten" },
                {11 , "eleven" },
                {12 , "twelve" },
                {13 , "thirteen" },
                {14 , "fourteen" },
                {15 , "fifteen" },
                {16 , "sixteen" },
                {17 , "seventeen" },
                {18 , "eighteen" },
                {19 , "nineteen" },
                {20 , "twenty" },
                {30 , "thirty" },
                {40 , "fourty" },
                {50 , "fifty" },
                {60 , "sixty" },
                {70 , "seventy" },
                {80 , "eighty" },
                {90 , "ninety" },
            };
        private readonly ILogger<NumberConverter> _logger;

        public NumberConverter(ILogger<NumberConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Convert string number to text number up to million
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertWord(string number)
        {
            string word = "";
            number =Convert.ToInt32(number.Replace(" ", "")).ToString();
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                int dblAmt = Convert.ToInt32(number);

                if (dblAmt > 0)
                {
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length; int pos = 0;
                    string place = "";

                    switch (numDigits)
                    {
                        case 1://Ones    
                            word = GetOnesNumber(number);
                            isDone = true;
                            break;
                        case 2://Tens   
                            word = GetTensNumber(number);
                            isDone = true;
                            break;
                        case 3://Hundreds    
                            pos = (numDigits % 3) + 1;
                            place = " hundred ";
                            break;
                        case 4://Thousands    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " thousand ";
                            break;
                        case 7://Millions    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " million ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (number.Substring(0, pos) != "0" && number.Substring(pos) != "0")
                            word = ConvertWord(number.Substring(0, pos)) + place + ConvertWord(number.Substring(pos));
                        else
                            word = ConvertWord(number.Substring(0, pos)) + ConvertWord(number.Substring(pos));
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                word = "Error";
            }
            return word.Trim();
        }
        private string GetTensNumber(string number)
        {
            string name = "";
            int _number = Convert.ToInt32(number);
            bool isTensNumber = TensWords.Where(x => x.Key == _number).Count() > 0;
            if (!isTensNumber && _number > 0)
                name = GetTensNumber(number.Substring(0, 1) + "0") + "-" + GetOnesNumber(number.Substring(1));
            else
                name = TensWords[_number];
            return name;
        }
        private string GetOnesNumber(string number)
        {
            int _number = Convert.ToInt32(number);
            return OnesWords[_number];
        }
    }
}

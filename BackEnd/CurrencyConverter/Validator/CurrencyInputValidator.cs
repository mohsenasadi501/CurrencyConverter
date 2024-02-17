using FluentValidation;
namespace CurrencyConverter.Validator
{
    public class CurrencyInputValidator : AbstractValidator<string>
    {
        public CurrencyInputValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Input string number cannot be empty.");

            RuleFor(x => x)
                .Matches("^[0-9,\\s]*$")
                .WithMessage("Input string number should only contain numbers, spaces, and commas.");

            RuleFor(x => x)
                .Must(HaveExactlyOneComma)
                .WithMessage("Input string number should have exactly one comma.");

            RuleFor(x => x)
               .Must(HaveNineNumberBeforeComma)
               .WithMessage("Input string number should have exactly nine number before comma.");

            RuleFor(x => x)
               .Must(HaveTwoNumberAfterComma)
               .WithMessage("Input string number should have exactly two number after comma.");
        }
        private static bool HaveExactlyOneComma(string input)
        {
            int commaCount = input.Count(c => c == ',');
            return commaCount == 0 || commaCount == 1;
        }
        private static bool HaveNineNumberBeforeComma(string input)
        {
            input = input.Replace(" ", "");
            int commaCount = input.Count(c => c == ',');
            if (commaCount != 0)
            {
                string[] strArray = input.Split(',');
                input = strArray[0];
            }
            return input.Length <= 9;
        }
        private static bool HaveTwoNumberAfterComma(string input)
        {
            input = input.Replace(" ", "");
            int commaCount = input.Count(c => c == ',');
            if (commaCount != 0)
            {
                string[] strArray = input.Split(',');
                return strArray[1].Length <= 2;
            }
            else
                return true;
        }
    }
}

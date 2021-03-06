using System.Text.RegularExpressions;

namespace Validation
{
    public class PersianCharValidation : IPersianCharValidation
    {
        public bool Execute(string input)
        {
            return Regex.IsMatch(input, @"^([\u0600-\u06FF]+\s?)+$");
        }
    }
}
using System.Text.RegularExpressions;

namespace Validation
{
    public class DigitsValidation : IDigitsValidation
    {
        public bool Execute(string input)
        {
            return Regex.IsMatch(input,@"^[\p{N}]+$");
        }
    }
}
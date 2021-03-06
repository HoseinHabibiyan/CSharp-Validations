using System.Text.RegularExpressions;
using Exception;

namespace Validation
{
    public class PostalCodeValidation : IPostalCodeValidation
    {
        public bool Execute(string input)
        {
            if (input.Length != 10)
                throw new PostalCodeShouldBeTenDigitsException();

            if (Regex.IsMatch(input, "^([0-9])\\1*$")) // check if all digits is same
                throw new PostalCodeIsNotValidException();

            if (Regex.IsMatch(input, "[02]")) // Postal Code Can Not Contains 0 and 2
                throw new PostalCodeIsNotValidException();

            if (Regex.IsMatch(input.Substring(0, 3), "^([0-9])\\1*$")) // 4 elementary Digit Can not be Same
                throw new PostalCodeIsNotValidException();

            if (input.ToCharArray()[4].ToString() == "5") 
                throw new PostalCodeIsNotValidException();

            return true;
        }
    }
}
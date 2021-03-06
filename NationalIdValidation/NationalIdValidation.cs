using System.Text.RegularExpressions;
using Exception;

namespace Validation
{
    public class NationalIdValidation : INationalIdValidation
    {
        public bool Execute(string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
                throw new NationalIdShouldBeElevenDigitsException();


            if (nationalId.Length > 11 || nationalId.Length < 11)
                throw new NationalIdShouldBeElevenDigitsException();


            if (!Regex.IsMatch(nationalId, "[0-9]+"))
                throw new NationalIdIncorrectException();

            string nationalCodeWithoutControlDigit = nationalId.Substring(0, (nationalId.Length - 1));
            string controlDigit = nationalId.Substring((nationalId.Length - 1), 1);
            string nId = nationalId.Substring((nationalId.Length - 2), 1);
            int dec = (int.Parse(nId) + 2);
            int[] multiplier = new int[]
                {29, 27, 23, 19, 17, 29, 27, 23, 19, 17};
            int sum = 0;
            int i = 0;
            foreach (char c in nationalCodeWithoutControlDigit.ToCharArray())
            {
                int temp = ((int.Parse(("" + c)) + dec)
                            * multiplier[i]);
                i++;
                sum = (sum + temp);
            }

            int result = (sum % 11);
            if ((result == 10))
            {
                result = 0;
            }

            if ((result == int.Parse(controlDigit)))
            {
                return true;
            }

            return false;
        }
    }
}
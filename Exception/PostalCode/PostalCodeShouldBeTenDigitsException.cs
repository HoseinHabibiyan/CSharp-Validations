namespace PostalCode
{
    public class PostalCodeShouldBeTenDigitsException : System.Exception
    {
        public PostalCodeShouldBeTenDigitsException():base("Postal Code Should Be 10 Digits")
        {
            
        }
    }
}
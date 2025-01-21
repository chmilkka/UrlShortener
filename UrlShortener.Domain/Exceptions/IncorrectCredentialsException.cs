namespace UrlShortener.Domain.Exceptions
{
    public class IncorrectCredentialsException : Exception
    {
        public IncorrectCredentialsException() : base("Incorrect email or password") { }
    }
}

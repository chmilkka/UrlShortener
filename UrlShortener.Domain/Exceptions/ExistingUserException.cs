namespace UrlShortener.Domain.Exceptions
{
    public class ExistingUserException : Exception
    {
        public ExistingUserException() : base("User already exists.") { }
    }
}

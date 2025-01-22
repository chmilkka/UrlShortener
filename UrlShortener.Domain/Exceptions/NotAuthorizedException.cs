namespace UrlShortener.Domain.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException() : base("You are not authorized.") { }
    }
}

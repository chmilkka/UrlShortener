namespace UrlShortener.Infrastructure.Configuration
{
    public class JwtSettings
    {
        public const string SecretKey = "top-secret-key";
        public const string Issuer = "UrlShortenerAPI";
        public const string Audience = "UrlShortenerUser";
    }
}

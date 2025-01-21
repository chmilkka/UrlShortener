using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Infrastructure.Configuration
{
    public class JwtSettings
    {
        public const string SecretKey = "top-secret-key";
        public const string Issuer = "UrlShortenerAPI";
        public const string Audience = "UrlShortenerUser";
    }
}

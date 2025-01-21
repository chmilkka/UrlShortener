using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Services.JwtTokenService
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Services.JwtTokenService
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}

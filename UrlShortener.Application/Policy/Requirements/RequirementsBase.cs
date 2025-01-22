using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using UrlShortener.Domain.Enums;

namespace UrlShortener.Application.Policy.Requirements
{
    public class RequirementsBase
    {
        public Task VerifyRole(AuthorizationHandlerContext context, IAuthorizationRequirement requirement, Role role)
        {
            var httpContext = (HttpContext)context.Resource!;

            if (httpContext.User.Claims.Any(x => x.Type == JwtRegisteredClaimNames.Typ && x.Value == role.ToString()))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

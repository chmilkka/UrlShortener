using Microsoft.AspNetCore.Authorization;

namespace UrlShortener.Application.Policy.Requirements
{
    public class AdminRoleRequirement : IAuthorizationRequirement { }
}

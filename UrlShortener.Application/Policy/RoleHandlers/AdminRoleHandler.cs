using Microsoft.AspNetCore.Authorization;
using UrlShortener.Application.Policy.Requirements;
using UrlShortener.Domain.Enums;

namespace UrlShortener.Application.Policy.RoleHandlers
{
    public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
            => new RequirementsBase().VerifyRole(context, requirement, Role.Admin);
    }
}

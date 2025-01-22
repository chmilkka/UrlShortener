using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Policy.Requirements;
using UrlShortener.Domain.Enums;

namespace UrlShortener.Application.Policy.RoleHandlers
{
    public class UserRoleHandler : AuthorizationHandler<UserRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleRequirement requirement)
            => new RequirementsBase().VerifyRole(context, requirement, Role.User);
    }
}

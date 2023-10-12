using Microsoft.AspNetCore.Authorization;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Role[] Roles { get; set; }

        public RoleAccessRequirement(params Role[] roles)
        {
            Roles = roles;
        }
    }
}

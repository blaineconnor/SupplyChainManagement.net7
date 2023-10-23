using Microsoft.AspNetCore.Authorization;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Authorizations[] Auths { get; set; }

        public RoleAccessRequirement(params Authorizations[] auths)
        {
            Auths = auths;
        }
    }
}

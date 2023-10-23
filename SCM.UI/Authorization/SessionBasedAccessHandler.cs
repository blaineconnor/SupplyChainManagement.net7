using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using SCM.UI.Models.DTOs.Accounts;

namespace SCM.UI.Authorization
{
    public class SessionBasedAccessHandler : AuthorizationHandler<RoleAccessRequirement>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionBasedAccessHandler(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAccessRequirement requirement)
        {
            var sessionKey = _configuration["Application:SessionKey"];

            if (_contextAccessor.HttpContext.Session?.GetString(sessionKey) is null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var userInfo = JsonConvert.DeserializeObject<TokenDTO>(_contextAccessor.HttpContext.Session?.GetString(sessionKey));
            if (requirement.Auths.Contains(userInfo.Auth))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Http;
using SCM.Domain.Entities;
using SCM.Domain.Services.Abstractions;
using System.Security.Claims;

namespace SCM.Domain.Services.Implementation
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId => GetClaim(ClaimTypes.PrimarySid) != null ? int.Parse(GetClaim(ClaimTypes.PrimarySid)) : null;

        public Role? Roles => GetClaim(ClaimTypes.Role) != null ? (Role)Enum.Parse(typeof(Role), GetClaim(ClaimTypes.Role)) : null;

        public string UserName => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;



        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}

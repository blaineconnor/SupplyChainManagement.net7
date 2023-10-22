using Microsoft.AspNetCore.Http;
using SCM.Domain.Entities;
using SCM.Domain.Services.Abstractions;
using System.Data;
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
        public Authorization? Auth => GetClaim(ClaimTypes.Role) != null ? (Authorization)Enum.Parse(typeof(Authorization), GetClaim(ClaimTypes.Role)) : null;
        public string UserName => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;
        public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;



        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}

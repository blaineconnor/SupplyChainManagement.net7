using SCM.Domain.Entities;

namespace SCM.Domain.Services.Abstractions
{
    public interface ILoggedUserService
    {
        int? UserId { get; }
        Role? Roles { get; }
        string UserName { get; }
        string Email { get; }
    }
}

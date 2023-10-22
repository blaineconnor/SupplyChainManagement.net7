using SCM.Domain.Entities;

namespace SCM.Domain.Services.Abstractions
{
    public interface ILoggedUserService
    {
        int? UserId { get; }
        Authorization? Auth { get; }
        string UserName { get; }
        string Email { get; }
    }
}

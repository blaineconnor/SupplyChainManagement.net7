using SCM.Domain.Entities;

namespace SCM.Domain.Services.Abstractions
{
    public interface ILoggedUserService
    {
        Int64? UserId { get; }
        Int64? SupplierId { get; }
        Authorization? Auth { get; }
        string UserName { get; }
        string Email { get; }
    }
}

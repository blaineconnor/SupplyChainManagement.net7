using SCM.Application.Models.RequestModels.Roles;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface IRoleService
    {
        Task<Result<BigInteger>> CreateRole(CreateRoleVM createRoleVM);
        Task<Result<BigInteger>> DeleteRole(DeleteRoleVM deleteRoleVM);
    }
}

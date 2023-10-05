using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM registerVM);

        Task<Result<TokenDTO>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);

    }
}

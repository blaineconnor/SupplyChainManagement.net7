using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);

        Task<Result<TokenDTO>> Login(LoginVM loginVM);

    }
}

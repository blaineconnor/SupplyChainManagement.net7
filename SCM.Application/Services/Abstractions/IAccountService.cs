using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;

namespace SCM.Application.Services.Abstractions
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM registerVM);

        Task<Result<TokenDTO>> Login(LoginVM loginVM);

        Task<Result<Account>> GetByIdAsync(int id);

        Task<Result<bool>> UpdateUserRoles(string username, Role newRoles);
        Task<Result<bool>> UpdateUserCompany(string username, Company newCompany);

    }
}

using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.RequestModels.Companies;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface ICompanyService
    {
        #region Select
        Task<Result<List<CompanyDTO>>> GetAllCompanies();
        Task<Result<CompanyDTO>> GetCompanyById(GetCompanyByIdVM getCompanyByIdVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<BigInteger>> CreateCompany(CreateCompanyVM createCompanyVM);
        Task<Result<BigInteger>> UpdateCompany(UpdateCompanyVM updateCompanyVM);
        Task<Result<BigInteger>> DeleteCompany(DeleteCompanyVM deleteCompanyVM);
        #endregion
    }
}

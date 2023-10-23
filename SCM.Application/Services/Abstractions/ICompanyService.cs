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
        Task<Result<Int64>> CreateCompany(CreateCompanyVM createCompanyVM);
        Task<Result<Int64>> UpdateCompany(UpdateCompanyVM updateCompanyVM);
        Task<Result<Int64>> DeleteCompany(DeleteCompanyVM deleteCompanyVM);
        #endregion
    }
}

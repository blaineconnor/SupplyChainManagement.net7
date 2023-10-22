using SCM.Application.Models.DTOs.Departments;
using SCM.Application.Models.RequestModels.Departments;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface IDepartmentService
    {
        #region Select
        Task<Result<List<DepartmentDTO>>> GetAllDepartments();
        Task<Result<DepartmentDTO>> GetDepartmentById(GetDepartmentByIdVM getDepartmentByIdVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<BigInteger>> CreateDepartment(CreateDepartmentVM createDepartmenVM);
        Task<Result<BigInteger>> UpdateDepartment(UpdateDepartmentVM updateDepartmentVM);
        Task<Result<BigInteger>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM);
        #endregion
    }
}

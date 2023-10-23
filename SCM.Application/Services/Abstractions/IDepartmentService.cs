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
        Task<Result<Int64>> CreateDepartment(CreateDepartmentVM createDepartmenVM);
        Task<Result<Int64>> UpdateDepartment(UpdateDepartmentVM updateDepartmentVM);
        Task<Result<Int64>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM);
        #endregion
    }
}

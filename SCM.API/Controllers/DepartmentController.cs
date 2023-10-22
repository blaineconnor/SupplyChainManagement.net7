using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.DTOs.Departments;
using SCM.Application.Models.RequestModels.Companies;
using SCM.Application.Models.RequestModels.Departments;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("get")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<List<DepartmentDTO>>>> GetAllDepartments()
        {
            var department = await _departmentService.GetAllDepartments();
            return Ok(department);
        }

        [HttpGet("get/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<DepartmentDTO>>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(new GetDepartmentByIdVM { Id = id });
            return Ok(department);
        }

        [HttpPost("create")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var departmentId = await _departmentService.CreateDepartment(createDepartmentVM);
            return Ok(departmentId);
        }

        [HttpPut("update/{id:int}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> UpdateDepartment(int id, UpdateDepartmentVM updateDepartmentVM)
        {
            if (id != updateDepartmentVM.Id)
            {
                return BadRequest();
            }
            var departmentId = await _departmentService.UpdateDepartment(updateDepartmentVM);
            return Ok(departmentId);
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> DeleteDepartment(int id)
        {
            var departmentId = await _departmentService.DeleteDepartment(new DeleteDepartmentVM { Id = id });
            return Ok(departmentId);
        }
    }
}

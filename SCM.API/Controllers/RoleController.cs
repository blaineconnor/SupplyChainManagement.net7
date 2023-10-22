using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.DTOs.Roles;
using SCM.Application.Models.RequestModels.Companies;
using SCM.Application.Models.RequestModels.Roles;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;

        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }        
      

        [HttpPost("create")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> CreateRole(CreateRoleVM createRoleVM)
        {
            var RoleId = await _RoleService.CreateRole(createRoleVM);
            return Ok(RoleId);
        }

       
        [HttpDelete("delete/{id:int}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> DeleteRole(int id)
        {
            var RoleId = await _RoleService.DeleteRole(new DeleteRoleVM { Id = id });
            return Ok(RoleId);
        }
    }
}

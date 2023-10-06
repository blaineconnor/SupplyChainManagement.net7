using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveController : ControllerBase
    {
        private readonly IApproveService _approveService;

        public ApproveController(IApproveService approveService)
        {
            _approveService = approveService;
        }

        [HttpPut("Approve/Deny")]
        public async Task<ActionResult<Result<bool>>> Approve(int id, ApproveVM approveVM)
        {
            if (id != approveVM.RequestId)
            {
                return BadRequest();
            }
            var requestId = await _approveService.IsApproved(approveVM);
            return Ok(requestId);
        }
    }
}

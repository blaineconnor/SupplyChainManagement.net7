using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;
using SCM.Application.Services.Implementations;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class ApproveController : ControllerBase
    {
        private readonly IApproveService _approveService;

        public ApproveController(IApproveService approveService)
        {
            _approveService = approveService;
        }

        [HttpPut("manager-approve")]
        public async Task<IActionResult> ManagerApprove( ApproveVM approveVM)
        {
            var result = await _approveService.ManagerApprove(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("manager-reject")]
        public async Task<IActionResult> ManagerReject( ApproveVM approveVM)
        {
            var result = await _approveService.ManagerReject(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("approve/{id}")]
        public async Task<ActionResult<Result<bool>>> ApproveOffer(int id)
        {
            var result = await _approveService.ApproveOffer(new ApproveVM { RequestId = id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("reject/{id}")]
        public async Task<ActionResult<Result<bool>>> RejectOffer(int id, string rejectionReason)
        {
            var result = await _approveService.RejectOffer(new ApproveVM { RequestId = id }, rejectionReason);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}


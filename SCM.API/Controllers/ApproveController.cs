using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
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

        [HttpPost("manager-Approve")]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<ActionResult<Result<bool>>> ManagerApprove(ManagerApproveVM approveVM)
        {
            var result = await _approveService.ManagerApprove(approveVM);
            return Ok(result);
        }

        [HttpPost("reject")]
        [Authorize(Policy = "MPPolicy")]
        public async Task<ActionResult<Result<bool>>> Reject(RejectVM approveVM, string rejectionReason)
        {
            var result = await _approveService.Reject(approveVM, rejectionReason);
            return Ok(result);
        }

        [HttpPost("Purchasing-Approve")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<bool>>> PurchasingApprove(ApproveVM approveVM)
        {
            var result = await _approveService.PurchasingApprove(approveVM);
            return Ok(result);
        }

        [HttpPost("Admin-Approve")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<bool>>> AdminApprove(ApproveVM approveVM)
        {
            var result = await _approveService.AdminApprove(approveVM);
            return Ok(result);
        }

        [HttpPost("SuperAdmin-Approve")]
        [Authorize(Policy = "SuperAdminPolicy")]
        public async Task<ActionResult<Result<bool>>> SuperAdminApprove(ApproveVM approveVM)
        {
            var result = await _approveService.SuperAdminApprove(approveVM);
            return Ok(result);
        }
    }
}


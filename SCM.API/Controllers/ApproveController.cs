using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;
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

        [HttpPost("manager-approve")]
        public async Task<ActionResult<Result<bool>>> ManagerApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.ManagerApprove(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("manager-reject")]
        public async Task<ActionResult<Result<bool>>> ManagerReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.ManagerReject(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("purchasing-approve")]
        public async Task<ActionResult<Result<bool>>> PurchasingApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.PurchasingApprove(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("purchasing-reject")]
        public async Task<ActionResult<Result<bool>>> PurchasingReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.PurchasingReject(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("admin-approve")]
        public async Task<ActionResult<Result<bool>>> AdminApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.AdminApprove(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("admin-reject")]
        public async Task<ActionResult<Result<bool>>> AdminReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.AdminReject(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("superadmin-approve")]
        public async Task<ActionResult<Result<bool>>> SuperAdminApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.SuperAdminApprove(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("superadmin-reject")]
        public async Task<ActionResult<Result<bool>>> SuperAdminReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.SuperAdminReject(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("accounting-fulfillment")]
        public async Task<ActionResult<Result<bool>>> AccountingFulfillment([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.AccountingFulfillment(approveVM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}


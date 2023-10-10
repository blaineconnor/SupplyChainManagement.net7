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
        public async Task<IActionResult> ManagerApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.ManagerApprove(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("manager-reject")]
        public async Task<IActionResult> ManagerReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.ManagerReject(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("purchasing-approve")]
        public async Task<IActionResult> PurchasingApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.PurchasingApprove(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("purchasing-reject")]
        public async Task<IActionResult> PurchasingReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.PurchasingReject(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("admin-approve")]
        public async Task<IActionResult> AdminApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.AdminApprove(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("admin-reject")]
        public async Task<IActionResult> AdminReject([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.AdminReject(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("superadmin-approve")]
        public async Task<IActionResult> SuperAdminApprove([FromBody] ApproveVM approveVM)
        {
            var result = await _approveService.SuperAdminApprove(approveVM);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("superadminreject")]
        public async Task<IActionResult> SuperAdminReject([FromBody] ApproveVM approveVM, [FromBody] string rejectionReason)
        {
            var result = await _approveService.SuperAdminReject(approveVM, rejectionReason);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}


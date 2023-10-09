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

        [HttpPost("process")]
        public async Task<IActionResult> ProcessRequest([FromBody] ApproveVM approveVM)
        {
            if (approveVM == null)
            {
                return BadRequest("Geçersiz istek verisi.");
            }

            var isApproved = approveVM.IsApproved;
            var result = await _approveService.ProcessRequest(approveVM, isApproved);

            if (result.Success)
            {
                return Ok(new { success = true, message = isApproved ? "Talep başarıyla onaylandı." : "Talep başarıyla reddedildi." });
            }
            else
            {
                return BadRequest(new { success = false, errors = result.Errors });
            }
        }

        [HttpPost("approve/{id:int}")]
        public async Task<ActionResult<Result<bool>>> ApproveRequest(int id)
        {
            var approveVM = new ApproveVM { RequestId = id, IsApproved = true };
            var result = await _approveService.ApproveRequest(approveVM);
            if (result.Success)
            {
                return Ok(new Result<bool> { Data = true, Success = true, Message = "Talep başarıyla onaylandı." });
            }
            return BadRequest(new Result<bool> { Data = false, Errors = result.Errors });
        }

        [HttpPost("reject/{id:int}")]
        public async Task<ActionResult<Result<bool>>> RejectRequest(int id)
        {
            var approveVM = new ApproveVM { RequestId = id, IsApproved = false };
            var result = await _approveService.RejectRequest(approveVM);
            if (result.Success)
            {
                return Ok(new Result<bool> { Data = true, Success = true, Message = "Talep başarıyla reddedildi." });
            }
            return BadRequest(new Result<bool> { Data = false, Errors = result.Errors });
        }
    }
}

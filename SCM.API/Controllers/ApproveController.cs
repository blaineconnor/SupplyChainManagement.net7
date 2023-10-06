using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;

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
    }
}

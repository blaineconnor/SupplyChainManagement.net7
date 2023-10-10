using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Services.Abstractions;

namespace SCM.API.Controllers
{
    [Route("api/accounting")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IApproveService _approveService;

        public AccountingController(IApproveService approveService)
        {
            _approveService = approveService;
        }

        [HttpPost("fulfillment")]
        public async Task<IActionResult> Fulfillment()
        {
            var result = await _approveService.AccountingFulfillment();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

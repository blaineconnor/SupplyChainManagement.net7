using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;

namespace SCM.API.Controllers
{
    [Route("accounting")]
    [ApiController]
    [Authorize(Policy = "AccountingPolicy")]

    public class AccountingController : ControllerBase
    {
        private readonly IApproveService _approveService;

        public AccountingController(IApproveService approveService)
        {
            _approveService = approveService;
        }

        [HttpPost("fulfillment")]
        public async Task<IActionResult> Fulfillment(AccountingVM accountingVM)
        {
            var result = await _approveService.AccountingFulfillment(accountingVM);
            return Ok(result);
        }
    }
}

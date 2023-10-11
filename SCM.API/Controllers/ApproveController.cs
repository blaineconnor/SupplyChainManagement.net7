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

        [HttpPut("manager-approve")]
        public async Task<ActionResult<Result<bool>>> ManagerApprove(ApproveVM approveVM)
        {
            var result = await _approveService.ManagerApprove(approveVM);

            return Ok(result);

        }

        [HttpPut("manager-reject")]
        public async Task<ActionResult<Result<bool>>> ManagerReject(ApproveVM approveVM)
        {
            var result = await _approveService.ManagerReject(approveVM);


            return Ok(result);

        }

        [HttpPut("approve")]
        public async Task<ActionResult<Result<bool>>> ApproveOffer(ApproveVM approveVM)
        {
            var result = await _approveService.ApproveOffer(approveVM);

            return Ok(result);

        }

        [HttpPut("reject")]
        public async Task<ActionResult<Result<bool>>> RejectOffer(ApproveVM approveVM, string rejectionReason)
        {
            var result = await _approveService.RejectOffer(approveVM, rejectionReason);

            return Ok(result);

        }
    }
}


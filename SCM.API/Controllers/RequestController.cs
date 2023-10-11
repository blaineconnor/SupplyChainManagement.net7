using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("user/{userId:int}")]
        [Authorize(Policy = "MPPolicy")]
        public async Task<ActionResult<Result<List<RequestDTO>>>> GetRequestsByUser(int userId)
        {
            var result = await _requestService.GetRequestsByUser(new GetRequestsByUserVM { UserId = userId });
            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> CreateRequest(CreateRequestVM createRequestVM)
        {
            var requestId = await _requestService.CreateRequest(createRequestVM);
            return Ok(requestId);
        }

        [HttpPut("update/{requestId:int}")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> UpdateRequest(int requestId, UpdateRequestVM updateRequestVM)
        {
            if (requestId != updateRequestVM.RequestId)
            {
                return BadRequest("Invalid request ID.");
            }

            var updatedRequestId = await _requestService.UpdateRequest(updateRequestVM);
            return Ok(updatedRequestId);
        }

        [HttpDelete("delete/{requestId:int}")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> DeleteRequest(int requestId)
        {
            var deletedRequestId = await _requestService.DeleteRequest(new DeleteRequestVM { RequestId = requestId });
            return Ok(deletedRequestId);
        }
    }
}

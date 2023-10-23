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

        [HttpGet("get/{id}")]
        [Authorize(Policy = "MPPolicy")]
        public async Task<ActionResult<Result<List<RequestDTO>>>> GetRequestsByUser(int employeeId)
        {
            var result = await _requestService.GetRequestsByUser(new GetRequestsByUserVM { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> CreateRequest(CreateRequestVM createRequestVM)
        {
            var requestId = await _requestService.CreateRequest(createRequestVM);
            return Ok(requestId);
        }

        [HttpPut("update/{Id:int}")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> UpdateRequest(int requestId, UpdateRequestVM updateRequestVM)
        {
            if (requestId != updateRequestVM.Id)
            {
                return BadRequest("Invalid request ID.");
            }

            var updatedRequestId = await _requestService.UpdateRequest(updateRequestVM);
            return Ok(updatedRequestId);
        }

        [HttpDelete("delete/{Id:int}")]
        [Authorize(Policy = "EmployeePolicy")]
        public async Task<ActionResult<Result<int>>> DeleteRequest(int requestId)
        {
            var deletedRequestId = await _requestService.DeleteRequest(new DeleteRequestVM { Id = requestId });
            return Ok(deletedRequestId);
        }
    }
}

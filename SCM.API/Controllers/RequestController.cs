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


        [HttpGet("getByCustomer/{id:int?}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<List<RequestDTO>>>> GetRequestsByUser(int userId)
        {
            var categories = await _requestService.GetRequestsByUser(new GetRequestsByUserVM { UserId = userId });
            return Ok(categories);
        }


        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateRequest(CreateRequestVM createRequestVM)
        {
            var requestId = await _requestService.CreateRequest(createRequestVM);
            return Ok(requestId);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateRequest(int id, UpdateRequestVM updateRequestVM)
        {
            if (id != updateRequestVM.RequestId)
            {
                return BadRequest();
            }
            var requestId = await _requestService.UpdateRequest(updateRequestVM);
            return Ok(requestId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteRequest(int id)
        {
            var requestId = await _requestService.DeleteRequest(new DeleteRequestVM { RequestId = id });
            return Ok(requestId);
        }

    }
}

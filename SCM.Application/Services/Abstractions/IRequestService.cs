using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IRequestService
    {
        Task<Result<List<RequestDTO>>> GetRequestsByUser(GetRequestsByUserVM getRequestsByUserVM);
        Task<Result<int>> CreateRequest(CreateRequestVM createRequestVM);
        Task<Result<int>> UpdateRequest(UpdateRequestVM updateRequestVM);
        Task<Result<int>> DeleteRequest(DeleteRequestVM deleteRequestVM);
    }
}

using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface IRequestService
    {
        Task<Result<List<RequestDTO>>> GetRequestsByUser(GetRequestsByUserVM getRequestsByUserVM);
        Task<Result<BigInteger>> CreateRequest(CreateRequestVM createRequestVM);
        Task<Result<BigInteger>> UpdateRequest(UpdateRequestVM updateRequestVM);
        Task<Result<BigInteger>> DeleteRequest(DeleteRequestVM deleteRequestVM);
    }
}

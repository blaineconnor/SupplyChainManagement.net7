using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IRequestService
    {
        #region Select
        Task<Result<List<RequestDTO>>> GetRequestsByUser(GetRequestsByUserVM getRequestsByUserVM);
        #endregion

        #region Insert, Update, Delete
        Task<Result<int>> CreateRequest(CreateRequestVM createRequestVM);
        Task<Result<int>> DeleteRequest(DeleteRequestVM deleteRequestVM);
        Task<Result<int>> UpdateRequest(UpdateRequestVM updateRequestVM);
        #endregion
    }
}

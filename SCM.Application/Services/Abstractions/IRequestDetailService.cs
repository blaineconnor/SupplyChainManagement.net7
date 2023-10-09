using SCM.Application.Models.DTOs.RequestDetails;
using SCM.Application.Models.RequestModels.RequestDetails;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IRequestDetailService
    {
        #region Insert, Delete, Get
        Task<Result<int>> CreateRequestDetail(CreateRequestDetailVM createRequestDetailVM);
        Task<Result<int>> DeleteRequestDetail(DeleteRequestDetailVM deleteRequestDetailVM);
        Task<Result<List<RequestDetailDTO>>> GetRequestDetailsByRequestId(GetRequestDetailsByRequestIdVM getRequestDetailsByRequestIdVM);
        #endregion
    }
}

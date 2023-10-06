using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IApproveService
    {
        Task<Result<bool>> ApproveRequest(ApproveVM approveVM);

        Task<Result<bool>> ProcessRequest(ApproveVM approveVM, bool isApproved);

        Task<Result<bool>> RejectRequest(ApproveVM approveVM);
    }
}

using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IApproveService
    {
        Task<Result<bool>> ManagerApprove(ApproveVM approveVM);
        Task<Result<bool>> ManagerReject(ApproveVM approveVM);
        Task<Result<bool>> ApproveOffer(ApproveVM approveVM);
        Task<Result<bool>> RejectOffer(ApproveVM approveVM, string rejectionReason);
        Task<Result<bool>> AccountingFulfillment();
    }
}

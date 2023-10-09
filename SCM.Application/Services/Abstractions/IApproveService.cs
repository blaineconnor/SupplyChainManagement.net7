using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IApproveService
    {

        Task<Result<bool>> ManagerApprove(ApproveVM approveVM);
        Task<Result<bool>> ManagerReject(ApproveVM approveVM);
        Task<Result<bool>> PurchasingApprove(ApproveVM approveVM);
        Task<Result<bool>> PurchasingReject(ApproveVM approveVM);
        Task<Result<bool>> AdminApprove(ApproveVM approveVM);
        Task<Result<bool>> AdminReject(ApproveVM approveVM);
        Task<Result<bool>> SuperAdminApprove(ApproveVM approveVM);
        Task<Result<bool>> SuperAdminReject(ApproveVM approveVM);
        Task<Result<bool>> AccountingFulfillment(ApproveVM approveVM);
    }

}

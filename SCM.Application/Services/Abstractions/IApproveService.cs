﻿using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IApproveService
    {
        Task<Result<bool>> ManagerApprove(ApproveVM approveVM);
        Task<Result<bool>> PurchasingApprove(ApproveVM approveVM);
        Task<Result<bool>> AdminApprove(ApproveVM approveVM);
        Task<Result<bool>> SuperAdminApprove(ApproveVM approveVM);
        Task<Result<bool>> Reject(RejectVM approveVM, string rejectionReason);
    }
}

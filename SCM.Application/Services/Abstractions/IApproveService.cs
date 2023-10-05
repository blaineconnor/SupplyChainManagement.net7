using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IApproveService
    {
        Task<Result<bool>> IsApproved(ApproveVM approveVM);
    }
}

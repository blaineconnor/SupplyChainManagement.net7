using AutoMapper;
using Microsoft.Extensions.Configuration;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;

namespace SCM.Application.Services.Implementations
{
    public class ApproveService : IApproveService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public ApproveService(IUnitWork uWork, IMapper mapper)
        {
            _mapper = mapper;
            _uWork = uWork;
        }
        public async Task<Result<bool>> IsApproved(ApproveVM approveVM)
        {
            var result = new Result<bool>();

            var existsRequest = await _uWork.GetRepository<Approves>().GetById(approveVM.RequestId);
            if (existsRequest is null)
            {
                throw new Exception($"{approveVM} numaralı talep bulunamadı.");
            }

            var updatedRequest = _mapper.Map(approveVM, existsRequest);

            _uWork.GetRepository<Approves>().Update(updatedRequest);
            await _uWork.CommitAsync();

            result.Data = updatedRequest.IsApproved;
            _uWork.Dispose();
            return result;
        }
    }
}

using AutoMapper;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.RequestModels.RequestDetails;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.RequestDetails;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;

namespace SCM.Application.Services.Implementations
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;

        public RequestDetailService(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        [ValidationBehavior(typeof(CreateRequestDetailValidator))]
        public async Task<Result<int>> CreateRequestDetail(CreateRequestDetailVM createRequestDetailVM)
        {
            var result = new Result<int>();

            var requestsExists = await _unitWork.GetRepository<RequestDetail>().AnyAsync(x => x.Id == createRequestDetailVM.RequestId);
            if (!requestsExists)
            {
                throw new NotFoundException($"{createRequestDetailVM.RequestId} numaralı talep bulunamadı.");
            }

            var productExists = await _unitWork.GetRepository<RequestDetail>().AnyAsync(x => x.ProductId == createRequestDetailVM.ProductId);
            if (productExists)
            {
                throw new NotFoundException($"{createRequestDetailVM.RequestId} numaralı talep için {createRequestDetailVM.ProductId} numaralı ürün daha önce eklenmiştir.");
            }

            var requestDetailEntity = _mapper.Map<RequestDetail>(createRequestDetailVM);

            _unitWork.GetRepository<RequestDetail>().Add(requestDetailEntity);
            await _unitWork.CommitAsync();

            result.Data = requestDetailEntity.Id;
            return result;
        }

        [ValidationBehavior(typeof(DeleteRequestDetailValidator))]
        public async Task<Result<int>> DeleteRequestDetail(DeleteRequestDetailVM deleteRequestDetailVM)
        {
            var result = new Result<int>();

            var existsRequestDetail = await _unitWork.GetRepository<RequestDetail>().GetById(deleteRequestDetailVM.RequestDetailId);
            if (existsRequestDetail is null)
            {
                throw new NotFoundException($"{deleteRequestDetailVM.RequestDetailId} numaralı ürün talep detayı bulunamadı.");
            }

            _unitWork.GetRepository<RequestDetail>().Delete(existsRequestDetail);
            await _unitWork.CommitAsync();

            result.Data = existsRequestDetail.Id;
            return result;
        }
    }
}

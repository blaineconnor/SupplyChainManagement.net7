using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.RequestDetails;
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

        #region Create

        [ValidationBehavior(typeof(CreateRequestDetailValidator))]
        public async Task<Result<int>> CreateRequestDetail(CreateRequestDetailVM createRequestDetailVM)
        {
            var result = new Result<int>();

            var requestExists = await _unitWork.GetRepository<Requests>().AnyAsync(x => x.Id == createRequestDetailVM.RequestId);
            if (!requestExists)
            {
                throw new NotFoundException($"{createRequestDetailVM.RequestId} numaralı talep bulunamadı.");
            }

            var productExists = await _unitWork.GetRepository<Product>().AnyAsync(x => x.Id == createRequestDetailVM.ProductId);
            if (!productExists)
            {
                throw new NotFoundException($"{createRequestDetailVM.ProductId} numaralı ürün bulunamadı.");
            }

            var requestDetailEntity = _mapper.Map<RequestDetail>(createRequestDetailVM);

            _unitWork.GetRepository<RequestDetail>().Add(requestDetailEntity);
            await _unitWork.CommitAsync();

            result.Data = requestDetailEntity.Id;
            return result;
        }

        #endregion

        #region Delete

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

        #endregion

        #region Get

        public async Task<Result<List<RequestDetailDTO>>> GetRequestDetailsByRequestId(GetRequestDetailsByRequestIdVM getRequestDetailsByRequestIdVM)
        {
            var result = new Result<List<RequestDetailDTO>>();

            var requestDetails = await _unitWork.GetRepository<RequestDetail>()
                .GetByFilterAsync(x => x.RequestId == getRequestDetailsByRequestIdVM.RequestId);

            var requestDetailDtos = await requestDetails
                .ProjectTo<RequestDetailDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            result.Data = requestDetailDtos;
            return result;
        }

        #endregion
    }
}

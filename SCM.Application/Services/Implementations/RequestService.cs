﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Requests;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using SCM.Utils;

namespace SCM.Application.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;

        public RequestService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        #region Create

        [ValidationBehavior(typeof(CreateRequestValidator))]
        public async Task<Result<Int64>> CreateRequest(CreateRequestVM createRequestVM)
        {
            var result = new Result<Int64>();            

            var requestEntity = _mapper.Map<Request>(createRequestVM);
            requestEntity.Status = RequestStatus.Pending;

            _uWork.GetRepository<Request>().Add(requestEntity);
            await _uWork.CommitAsync();            

            result.Data = requestEntity.Id;
            return result;
        }

        #endregion

        #region Delete

        [ValidationBehavior(typeof(DeleteRequestValidator))]
        public async Task<Result<Int64>> DeleteRequest(DeleteRequestVM deleteRequestVM)
        {
            var result = new Result<Int64>();

            // Talep var mı kontrol et
            var requestEntity = await _uWork.GetRepository<Request>().GetById(deleteRequestVM.RequestId);
            if (requestEntity is null)
            {
                throw new NotFoundException($"{deleteRequestVM.RequestId} numaralı talep bulunamadı.");
            }

            // Talep detaylarını al ve sil
            var requestDetailByOrder = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Id == deleteRequestVM.RequestId);
            if (requestDetailByOrder.Any())
            {
                await requestDetailByOrder.ForEachAsync(requestDetail =>
                {
                    _uWork.GetRepository<Request>().Delete(requestDetail);
                });
            }

            // Talebi sil
            _uWork.GetRepository<Request>().Delete(requestEntity);
            await _uWork.CommitAsync();

            result.Data = requestEntity.Id;
            return result;
        }

        #endregion

        #region Update

        [ValidationBehavior(typeof(UpdateRequestValidator))]
        public async Task<Result<Int64>> UpdateRequest(UpdateRequestVM updateRequestVM)
        {
            var result = new Result<Int64>();

            // Talep var mı kontrol et
            var requestExists = await _uWork.GetRepository<Request>().AnyAsync(x => x.Id == updateRequestVM.RequestId);
            if (!requestExists)
            {
                throw new NotFoundException($"{updateRequestVM.RequestId} numaralı talep bulunamadı.");
            }

            // Talebi al ve güncelle
            var requestEntity = await _uWork.GetRepository<Request>().GetById(updateRequestVM.RequestId);
            _mapper.Map(updateRequestVM, requestEntity);
            requestEntity.Status = RequestStatus.Pending;

            _uWork.GetRepository<Request>().Update(requestEntity);
            await _uWork.CommitAsync();         

            result.Data = requestEntity.Id;
            return result;
        }

        #endregion

        #region Get

        public async Task<Result<List<RequestDTO>>> GetRequestsByUser(GetRequestsByUserVM getRequestsByUserVM)
        {
            var result = new Result<List<RequestDTO>>();

            var requests = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Employee.Id == getRequestsByUserVM.UserId);

            var requestDtos = await requests.ProjectTo<RequestDTO>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = requestDtos;
            return result;
        }

        #endregion
    }
}

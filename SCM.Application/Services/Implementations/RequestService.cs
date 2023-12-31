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
using System.Numerics;

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
        public async Task<Result<long>> CreateRequest(CreateRequestVM createRequestVM)
        {
            var result = new Result<long>();            

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
        public async Task<Result<long>> DeleteRequest(DeleteRequestVM deleteRequestVM)
        {
            var result = new Result<long>();

            // Talep var mı kontrol et
            var requestEntity = await _uWork.GetRepository<Request>().GetById(deleteRequestVM.Id);
            if (requestEntity is null)
            {
                throw new NotFoundException($"{deleteRequestVM.Id} numaralı talep bulunamadı.");
            }

            // Talep detaylarını al ve sil
            var requestDetailByOrder = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Id == deleteRequestVM.Id);
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
        public async Task<Result<long>> UpdateRequest(UpdateRequestVM updateRequestVM)
        {
            var result = new Result<long>();

            // Talep var mı kontrol et
            var requestExists = await _uWork.GetRepository<Request>().AnyAsync(x => x.Id == updateRequestVM.Id);
            if (!requestExists)
            {
                throw new NotFoundException($"{updateRequestVM.Id} numaralı talep bulunamadı.");
            }

            // Talebi al ve güncelle
            var requestEntity = await _uWork.GetRepository<Request>().GetById(updateRequestVM.Id);
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

            var requests = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Employee.Id == getRequestsByUserVM.EmployeeId);

            var requestDtos = await requests.ProjectTo<RequestDTO>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = requestDtos;
            return result;
        }

        #endregion
    }
}

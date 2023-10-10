﻿using AutoMapper;
using SCM.Application.Models.DTOs.Offer;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
namespace SCM.Application.Services.Implementations
{
    public class OfferService : IOfferService
    {
        private readonly IUnitWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Get Methods
        public async Task<Result<OfferDTO>> GetOfferByIdAsync(int offerId)
        {
            var offer = await _unitOfWork.GetRepository<Offer>().GetById(offerId);
            if (offer == null)
            {
                return new Result<OfferDTO>
                {
                    Success = false,
                    Message = $"Teklif bulunamadı (ID: {offerId})."
                };
            }
            return new Result<OfferDTO>
            {
                Data = _mapper.Map<OfferDTO>(offer)
            };
        }

        public async Task<Result<List<OfferDTO>>> GetOffersByRequestIdAsync(int requestId)
        {
            var offers = await _unitOfWork.GetRepository<Offer>().GetByFilterAsync(o => o.RequestId == requestId);
            return new Result<List<OfferDTO>>
            {
                Data = _mapper.Map<List<OfferDTO>>(offers)
            };
        }

        public async Task<Result<List<OfferDTO>>> GetAllOffersAsync()
        {
            var offers = await _unitOfWork.GetRepository<Offer>().GetAllAsync();
            return new Result<List<OfferDTO>>
            {
                Data = _mapper.Map<List<OfferDTO>>(offers)
            };
        }

        #endregion

        #region Create
        public async Task<Result<bool>> CreateOfferAsync(CreateOfferVM createOfferVM)
        {
            var request = await _unitOfWork.GetRepository<Requests>()
                .GetSingleByFilterAsync(r => r.Id == createOfferVM.RequestId && r.Status == RequestStatus.ManagerApproved);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Message = "Onaylanmış bir talep bulunamadı."
                };
            }

            var offer = _mapper.Map<Offer>(createOfferVM);
            offer.RequestId = createOfferVM.RequestId;

            _unitOfWork.GetRepository<Offer>().Add(offer);
            await _unitOfWork.CommitAsync();

            request.Status = RequestStatus.OfferReceived;
            _unitOfWork.GetRepository<Requests>().Update(request);
            await _unitOfWork.CommitAsync();

            return new Result<bool>
            {
                Success = true,
                Message = "Teklif başarıyla kaydedildi ve talep durumu 'Teklif Ulaştı' olarak güncellendi."
            };
        }

        #endregion

        #region Update

        public async Task<Result<bool>> UpdateOfferAsync(UpdateOfferVM updateOfferVM)
        {
            var offer = await _unitOfWork.GetRepository<Offer>().GetById(updateOfferVM.Id);

            if (offer == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Message = $"Teklif bulunamadı (ID: {updateOfferVM.Id})."
                };
            }

            _mapper.Map(updateOfferVM, offer);
            _unitOfWork.GetRepository<Offer>().Update(offer);
            await _unitOfWork.CommitAsync();

            return new Result<bool>
            {
                Success = true,
                Data = true
            };
        }

        #endregion

        #region Delete

        public async Task<Result<bool>> DeleteOfferAsync(int offerId)
        {
            var offer = await _unitOfWork.GetRepository<Offer>().GetById(offerId);
            if (offer == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Message = $"Teklif bulunamadı (ID: {offerId})."
                };
            }
            _unitOfWork.GetRepository<Offer>().Delete(offer);
            await _unitOfWork.CommitAsync();
            return new Result<bool>
            {
                Data = true
            };
        }

        #endregion
    }
}

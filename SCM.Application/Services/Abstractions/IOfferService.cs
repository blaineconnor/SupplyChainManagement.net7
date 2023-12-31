﻿using SCM.Application.Models.DTOs.Offers;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IOfferService
    {
        Task<Result<OfferDTO>> GetOfferByIdAsync(Int64 offerId);
        Task<Result<OfferDTO>> GetOfferBySupplierId(Int64 supplierId);
        Task<Result<List<OfferDTO>>> GetOffersByRequest(GetAllOfferByRequestVM getAllOfferByRequestVM);
        Task<Result<bool>> CreateOfferAsync(CreateOfferVM createOfferVM);
        Task<Result<bool>> UpdateOfferAsync(UpdateOfferVM updateOfferVM);
        Task<Result<bool>> DeleteOfferAsync(Int64 offerId);
    }
}

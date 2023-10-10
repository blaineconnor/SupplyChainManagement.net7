﻿using SCM.Application.Models.DTOs.Offer;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IOfferService
    {
        Task<Result<OfferDTO>> GetOfferByIdAsync(int offerId);
        Task<Result<List<OfferDTO>>> GetOffersByRequestIdAsync(int requestId);
        Task<Result<List<OfferDTO>>> GetAllOffersAsync();
        Task<Result<bool>> CreateOfferAsync(CreateOfferVM createOfferVM);
        Task<Result<bool>> UpdateOfferAsync(UpdateOfferVM updateOfferVM);
        Task<Result<bool>> DeleteOfferAsync(int offerId);
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using SCM.Application.Models.DTOs.Offers;
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

        public async Task<Result<List<OfferDTO>>> GetOffersByRequest(GetAllOfferByRequestVM getAllOfferByRequestVM)
        {
            var result = new Result<List<OfferDTO>>();
            var ınvoicesEntity = await _unitOfWork.GetRepository<Offer>().GetByFilterAsync(x => x.RequestId == getAllOfferByRequestVM.Id);
            var invoiceDtos = ınvoicesEntity.ProjectTo<OfferDTO>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }
        #endregion

        #region Create
        public async Task<Result<bool>> CreateOfferAsync(CreateOfferVM createOfferVM)
        {
            var request = await _unitOfWork.GetRepository<Request>()
                .GetSingleByFilterAsync(r => r.Id == createOfferVM.RequestId && r.Status == RequestStatus.ManagerApproved || r.Status == RequestStatus.OfferReceived);

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
            _unitOfWork.GetRepository<Request>().Update(request);
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

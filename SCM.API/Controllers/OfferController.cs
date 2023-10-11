using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Offer;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("Offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        }

        [HttpGet("GetOfferByID")]
        public async Task<ActionResult<Result<OfferDTO>>> GetOfferById(int offerId)
        {
            var result = await _offerService.GetOfferByIdAsync(offerId);

            return Ok(result);

        }

        [HttpGet("GetOffersByRequestID")]
        public async Task<ActionResult<Result<List<OfferDTO>>>> GetOffersByRequestId(int requestId)
        {
            var result = await _offerService.GetOffersByRequestIdAsync(requestId);

            return Ok(result);

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<List<OfferDTO>>>> GetAllOffers()
        {
            var result = await _offerService.GetAllOffersAsync();
            return Ok(result);
        }

        [HttpPost("CreateOffer")]
        public async Task<ActionResult<Result<bool>>> CreateOffer([FromBody] CreateOfferVM createOfferVM)
        {
            var result = await _offerService.CreateOfferAsync(createOfferVM);
            return Ok(result);
        }

        [HttpPut("UpdateOffer")]
        public async Task<ActionResult<Result<bool>>> UpdateOffer(int offerId, [FromBody] UpdateOfferVM updateOfferVM)
        {
            if (offerId != updateOfferVM.Id)
            {
                return BadRequest("Teklif kimliği uyumsuz.");
            }

            var result = await _offerService.UpdateOfferAsync(updateOfferVM);
            return Ok(result);
        }

        [HttpDelete("DeleteOffer")]
        public async Task<ActionResult<Result<bool>>> DeleteOffer(int offerId)
        {
            var result = await _offerService.DeleteOfferAsync(offerId);
            if (result.Success)
            {
                return NoContent();
            }
            return NotFound(result);
        }
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Offer;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        }

        [HttpGet("getByOfferId")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<OfferDTO>>> GetOfferById(int offerId)
        {
            var result = await _offerService.GetOfferByIdAsync(offerId);

            return Ok(result);

        }

        [HttpGet("GetOffersByRequestID")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<List<OfferDTO>>>> GetOffersByRequestId(GetAllOfferByRequestVM getAllOfferByRequestVM)
        {
            var result = await _offerService.GetOffersByRequest(getAllOfferByRequestVM);

            return Ok(result);

        }

        [HttpPost("create")]
        [Authorize(Policy = "SupplierPolicy")]

        public async Task<ActionResult<Result<bool>>> CreateOffer([FromBody] CreateOfferVM createOfferVM)
        {
            var result = await _offerService.CreateOfferAsync(createOfferVM);
            return Ok(result);
        }

        [HttpPut("update")]
        [Authorize(Policy = "SupplierPolicy")]
        public async Task<ActionResult<Result<bool>>> UpdateOffer(int offerId, [FromBody] UpdateOfferVM updateOfferVM)
        {
            if (offerId != updateOfferVM.Id)
            {
                return BadRequest("Teklif kimliği uyumsuz.");
            }

            var result = await _offerService.UpdateOfferAsync(updateOfferVM);
            return Ok(result);
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "SupplierPolicy")]
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


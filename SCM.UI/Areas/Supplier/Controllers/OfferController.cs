using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Offers;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Offers;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Supplier.Controllers
{
    [Authorize(Policy = "SupplierPolicy")]
    public class OfferController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public OfferController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;

        }

        [HttpGet("/supplier/addoffer")]
        public IActionResult AddOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(CreateOfferVM createOfferVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createOfferVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"offer/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            if (response.Data.Data.Status != Enumarations.RequestStatus.ManagerApproved)
            {
                ModelState.AddModelError("", "Bu talebe teklif ekleyemezsiniz. İstek durumu 'Şube Müdürü Onaylı' olmalıdır.");
                return View();
            }

            var offerResponse = await _restService.PostAsync<Result<CreateOfferVM>>("offer/create");

            if (offerResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", offerResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{createOfferVM.RequestId} numaralı teklif başarıyla eklendi.";
                return RedirectToAction("List", "Offer", new { Area = "Supplier" });
            }
        }


        [HttpGet("/supplier/updateoffer")]
        public async Task<IActionResult> Edit(int id)
        {

            var response = await _restService.GetAsync<Result<OfferDTO>>($"offer/getByOfferId");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                var model = _mapper.Map<UpdateOfferVM>(response.Data.Data);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOfferVM updateOfferVM)
        {
            var response = await _restService.GetAsync<Result<RequestDTO>>($"offer/getByOfferId");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            if (response.Data.Data.Status != Enumarations.RequestStatus.OfferReceived)
            {
                ModelState.AddModelError("", "Bu talebin teklifini güncelleyemezsiniz. İstek durumu 'OfferReceived' olmalıdır.");
                return View();
            }

            var editResponse = await _restService.PutAsync<UpdateOfferVM, Result<int>>(updateOfferVM, $"offer/update/{updateOfferVM.Id}");

            if (editResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", editResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{updateOfferVM.Id} numaralı teklif başarıyla güncellendi.";
                return RedirectToAction("List", "Offer", new { Area = "Supplier" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var response = await _restService.DeleteAsync<Result<bool>>($"offer/delete");
            return Json(response.Data);
        }
    }
}

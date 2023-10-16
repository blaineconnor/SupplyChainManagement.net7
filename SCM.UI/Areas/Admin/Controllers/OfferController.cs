using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Offer;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Offers;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]

    public class OfferController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public OfferController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;

        }

        public IActionResult AddOffer()
        {
            ViewBag.Header = "Teklif İşlemleri";
            ViewBag.Title = "Yeni Teklif Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(CreateOfferVM createOfferVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createOfferVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"offer/get/{createOfferVM.RequestId}");

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

            var offerResponse = await _restService.PostAsync<Result<CreateOfferVM>>("offer/details");

            if (offerResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", offerResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{createOfferVM.RequestId} numaralı teklif başarıyla eklendi.";
                return RedirectToAction("List", "Offer");
            }
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Teklif İşlemleri";
            ViewBag.Title = "Teklif Düzenle";

            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("approve/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                var filteredData = response.Data.Data.Where(request => request.Status == Enumarations.RequestStatus.OfferReceived || request.Status == Enumarations.RequestStatus.ManagerApproved).ToList();
                return View(filteredData);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Header = "Teklif İşlemleri";
            ViewBag.Title = "Teklif Güncelle";

            var response = await _restService.GetAsync<Result<OfferDTO>>($"offer/get/{id}");

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
            var response = await _restService.GetAsync<Result<RequestDTO>>($"offer/get/{updateOfferVM.Id}");

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
                return RedirectToAction("List", "offer");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var response = await _restService.DeleteAsync<Result<bool>>($"offer/delete/{id}");
            return Json(response.Data);
        }
    }
}

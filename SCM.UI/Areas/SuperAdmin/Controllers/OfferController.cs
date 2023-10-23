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

namespace SCM.UI.Areas.SuperAdmin.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    [Area("SuperAdmin")]
    public class OfferController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public OfferController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;

        }


        [HttpGet("/superadmin/listoffers")]

        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("offer/getByOfferId");

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
                return RedirectToAction("List", "Offer", new { Area = "SuperAdmin" });
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

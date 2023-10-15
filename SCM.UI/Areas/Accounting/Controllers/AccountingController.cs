using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Approves;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Accounting.Controllers
{
    [Authorize(Policy = "AccountingPolicy")]
    [Area("Accounting")]
    public class AccountingController : Controller
    {
        private readonly IRestService _restService;

        public AccountingController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpPost]
        public async Task<IActionResult> Fulfillment(AccountingVM accountingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(accountingVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"accounting/get/{accountingVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.Data.Data.Status == Enumarations.RequestStatus.Rejected || response.Data.Data.Status == Enumarations.RequestStatus.Completed || response.Data.Data.Status == Enumarations.RequestStatus.OfferReceived || response.Data.Data.Status == Enumarations.RequestStatus.ManagerApproved || response.Data.Data.Status == Enumarations.RequestStatus.Pending)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            if (response.Data.Data.Status != Enumarations.RequestStatus.SuperAdminApproved || response.Data.Data.Status != Enumarations.RequestStatus.AdminApproved || response.Data.Data.Status != Enumarations.RequestStatus.PurchasingApproved)
            {
                ModelState.AddModelError("", "Bu isteği onaylayamazsınız. İstek durumu 'Onaylandı' olmalıdır.");
                return View();
            }
            var fulfillment = await _restService.PostAsync<Result<AccountingVM>>("accounting/details");

            if (fulfillment.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", fulfillment.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{accountingVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "Accounting");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Muhasebe İşlemleri";
            ViewBag.Title = "Faturalandırmaları göster";

            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("accounting/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                var filteredData = response.Data.Data.Where(request =>  request.Status == Enumarations.RequestStatus.PurchasingApproved || request.Status == Enumarations.RequestStatus.AdminApproved || request.Status == Enumarations.RequestStatus.SuperAdminApproved || request.Status == Enumarations.RequestStatus.Completed).ToList();
                return View(filteredData);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Invoices;
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

        [HttpGet("/accounting/fulfillment")]
        public IActionResult Fulfillment(int id)
        {
            var fulfillment = new CreateInvoiceVM() { RequestId = id };
            return View(fulfillment);
        }

        [HttpPost]
        public async Task<IActionResult> Fulfillment(CreateInvoiceVM accountingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(accountingVM);
            }

            var fulfillment = await _restService.PostAsync<CreateInvoiceVM, Result<int>>(accountingVM, "invoice/create");

            if (fulfillment.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", fulfillment.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{accountingVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "Accounting", new { Area = "Accounting" });
            }
        }

        [HttpGet("/accounting/listfullfilments")]
        public async Task<IActionResult> List()
        {
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

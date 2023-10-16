using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Approves;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Authorize(Policy = "PurchasingPolicy")]
    [Area("Purchasing")]
    public class PurchasingApproveController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;
        private readonly RequestDTO _requestDTO;
        public PurchasingApproveController(IRestService restService, IMapper mapper, RequestDTO requestDTO)
        {
            _restService = restService;
            _mapper = mapper;
            _requestDTO = requestDTO;
        }


        [HttpGet("/purchasing/approve")]
        public IActionResult PurchasingApprove()
        {           
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> PurchasingApprove(ApproveVM approveVM)
        {
            if (!ModelState.IsValid)
            {
                return View(approveVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"purchasingapprove/get/{approveVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest || response.Data.Data.Status == Enumarations.RequestStatus.AdminApproved || response.Data.Data.Status == Enumarations.RequestStatus.SuperAdminApproved || response.Data.Data.Status == Enumarations.RequestStatus.Rejected || response.Data.Data.Status == Enumarations.RequestStatus.PurchasingApproved)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            if (response.Data.Data.Status != Enumarations.RequestStatus.OfferReceived)
            {
                ModelState.AddModelError("", "Bu isteği onaylayamazsınız. İstek durumu 'Teklif Alındı' olmalıdır.");
                return View();
            }

            var approvalResponse = await _restService.PostAsync<Result<ApproveVM>>("purchasingapprove/details");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{approveVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "PurchasingApprove");
            }
        }

        [HttpGet("/purchasing/listapproves")]
        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("purchasingapprove/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                var filteredData = response.Data.Data.Where(request => request.Status == Enumarations.RequestStatus.OfferReceived || request.Status == Enumarations.RequestStatus.PurchasingApproved || request.Status == Enumarations.RequestStatus.AdminApproved || request.Status == Enumarations.RequestStatus.SuperAdminApproved || request.Status == Enumarations.RequestStatus.Completed).ToList();
                return View(filteredData);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Reject(RejectVM rejectVM)
        {

            if (!ModelState.IsValid)
            {
                return View(rejectVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"purchasingapprove/get/{rejectVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            var approvalResponse = await _restService.PostAsync<Result<RejectVM>>("purchasingapprove/details");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{rejectVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "PurchasingApprove");
            }
        }
    }
}

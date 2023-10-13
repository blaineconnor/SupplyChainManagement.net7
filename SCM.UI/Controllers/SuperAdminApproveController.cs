using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Approves;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    public class SuperAdminApproveController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;
        private readonly RequestDTO _requestDTO;
        public SuperAdminApproveController(IRestService restService, IMapper mapper, RequestDTO requestDTO)
        {
            _restService = restService;
            _mapper = mapper;
            _requestDTO = requestDTO;
        }


        public IActionResult SuperAdminApprove()
        {
            ViewBag.Header = "Satın Alma Onay İşlemleri";
            ViewBag.Title = "Onaylanacak Teklifleri Görüntüle";
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> SuperAdminApprove(ApproveVM approveVM)
        {
            if (!ModelState.IsValid)
            {
                return View(approveVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"superadminapprove/get/{approveVM.RequestId}");

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

            var approvalResponse = await _restService.PostAsync<Result<ApproveVM>>("superadminapprove/details");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{approveVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "SuperAdminApprove");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Onay İşlemleri";
            ViewBag.Title = "Onaylamaları göster";

            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("superadminapprove/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Reject(RejectVM rejectVM)
        {

            if (!ModelState.IsValid)
            {
                return View(rejectVM);
            }

            var response = await _restService.GetAsync<Result<RequestDTO>>($"superadminapprove/get/{rejectVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            var approvalResponse = await _restService.PostAsync<Result<RejectVM>>("superadminapprove/details");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{rejectVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "SuperAdminApprove");
            }
        }
    }
}

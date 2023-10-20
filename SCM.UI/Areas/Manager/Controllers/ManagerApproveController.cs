using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Approves;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Manager.Controllers
{
    [Authorize(Policy = "ManagerPolicy")]
    [Area("Manager")]
    public class ManagerApproveController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;
        private readonly RequestDTO _requestDTO;
        public ManagerApproveController(IRestService restService, IMapper mapper, RequestDTO requestDTO)
        {
            _restService = restService;
            _mapper = mapper;
            _requestDTO = requestDTO;
        }

        [HttpGet("/manager/managerapprove")]
        public IActionResult ManagerApprove()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ManagerApprove(ManagerApproveVM managerApproveVM)
        {
            if (!ModelState.IsValid)
            {
                return View(managerApproveVM);
            }

            var response = await _restService.PostAsync<Result<RequestDTO>>($"approve/get/{managerApproveVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            if (response.Data.Data.Status != Enumarations.RequestStatus.Pending)
            {
                ModelState.AddModelError("", "Bu isteği onaylayamazsınız. İstek durumu 'Beklemede' olmalıdır.");
                return View();
            }

            var approvalResponse = await _restService.PostAsync<Result<ManagerApproveVM>>("approve/managerapprove");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{managerApproveVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "ManagerApprove", new { Area = "Manager" });
            }
        }

        [HttpGet("/manager/listmanagerapproves")]
        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("approve/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                var filteredData = response.Data.Data.Where(request => request.Status == Enumarations.RequestStatus.Pending || request.Status == Enumarations.RequestStatus.ManagerApproved || request.Status == Enumarations.RequestStatus.Completed).ToList();
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

            var response = await _restService.GetAsync<Result<RequestDTO>>($"approve/get/{rejectVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }

            var approvalResponse = await _restService.PostAsync<Result<RejectVM>>("approve/reject");

            if (approvalResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", approvalResponse.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{rejectVM.RequestId} numaralı onay başarıyla girildi.";
                return RedirectToAction("List", "ManagerApprove", new { Area = "Manager" });
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Requests;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Authorize(Policy = "PurchasingPolicy")]
    [Area("Purchasing")]
    public class RequestController : Controller
    {
        private IRestService restService;
        private readonly IMapper _mapper;

        public RequestController(IRestService restService, IMapper mapper)
        {
            this.restService = restService;
            _mapper = mapper;
        }

        [HttpGet("/purchasing/createrequest")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestVM createRequestVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createRequestVM);
            }
            var response = await restService.PostAsync<Result<List<CreateRequestVM>>>("request/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{response.Data.Data} numaralı talep başarıyla eklendi.";
                return RedirectToAction("List", "Request", new { Area = "Purchasing" });
            }
        }
        
        [HttpGet("/purchasing/listrequests")]
        public async Task<IActionResult> List()
        {
            var response = await restService.GetAsync<Result<List<RequestDTO>>>("request/get");

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

        public async Task<IActionResult> Edit(int id)
        {
            var response = await restService.GetAsync<Result<RequestDTO>>($"requests/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                var model = _mapper.Map<UpdateRequestVM>(response.Data.Data);
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRequestVM updateRequestVM)
        {
            var response = await restService.PutAsync<UpdateRequestVM, Result<int>>(updateRequestVM, $"request/update/{updateRequestVM.RequestId}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{response.Data.Data} numaralı talep başarıyla güncellendi.";
                return RedirectToAction("List", "Request", new { Area = "Purchasing" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var response = await restService.DeleteAsync<Result<bool>>($"request/delete/{id}");
            return Json(response.Data);
        }
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.RequestModels.Requests;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class AdminRequestController : Controller
    {
        private IRestService restService;
        private readonly IMapper _mapper;

        public AdminRequestController(IRestService restService, IMapper mapper)
        {
            this.restService = restService;
            _mapper = mapper;
        }
        [HttpGet("/admin/createrequest")]

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
            var response = await restService.PostAsync<CreateRequestVM, Result<int>>(createRequestVM, "request/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{response.Data.Data} numaralı talep başarıyla eklendi.";
                return RedirectToAction("List", "Request", new { Area = "Admin" });
            }
        }
        
        [HttpGet("/admin/listrequests")]
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

        public async Task<IActionResult> Edit(long id)
        {
   

            var response = await restService.GetAsync<Result<RequestDTO>>($"request/get/{id}");

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
            var response = await restService.PutAsync<UpdateRequestVM, Result<int>>(updateRequestVM, $"request/update/{updateRequestVM.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{response.Data.Data} numaralı talep başarıyla güncellendi.";
                return RedirectToAction("List", "Request", new { Area = "Admin" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(long id)
        {
            var response = await restService.DeleteAsync<Result<bool>>($"request/delete/{id}");
            return Json(response.Data);
        }
    }
}

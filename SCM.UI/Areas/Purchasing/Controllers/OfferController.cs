using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models;
using SCM.UI.Models.DTOs.Requests;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Authorize(Policy = "PurchasingPolicy")]
    [Area("Purchasing")]
    public class OfferController : Controller
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public OfferController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;

        }
       
        [HttpGet("/purchasing/listoffers")]
        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<RequestDTO>>>("offer/get");

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
    }
}

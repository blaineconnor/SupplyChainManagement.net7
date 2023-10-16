using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models.DTOs.Products;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Manager.Controllers
{
    [Authorize(Policy = "ManagerPolicy")]
    [Area("Manager")]
    public class ProductController : Controller
    {
        private readonly IRestService _restService;

        public ProductController(IRestService restService)
        {
            _restService = restService;
        }       

        [HttpGet("/manager/listproducts")]
        public async Task<IActionResult> List()
        {           
            var response = await _restService.GetAsync<Result<List<ProductDTO>>>("product/getWithCategory");

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
    }
}

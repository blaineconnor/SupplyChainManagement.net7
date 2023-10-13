using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCM.UI.Models.DTOs.Categories;
using SCM.UI.Models.DTOs.Products;
using SCM.UI.Models.RequestModels.Products;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Controllers
{
    [Authorize(Policy = "AccountingPolicy")]
    public class ProductController : Controller
    {
        private readonly IRestService _restService;

        public ProductController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Header = "Ürün İşlemleri";
            ViewBag.Title = "Yeni Ürün Ekle";

            var response = await _restService.GetAsync<Result<List<CategoryDTO>>>("category/get");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                TempData["error"] = "Devam etmek için sisteme giriş yapmanız gerekmektedir.";
                return RedirectToAction("SignIn", "Login");
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                TempData["error"] = "Bu işlem için gerekli yetkiye sahip değilsiniz.";
                return RedirectToAction("SignIn", "Login");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                //Kategori listesini açılır kutuya uygun formata dönüşüm
                ViewBag.Categories = response.Data.Data.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createProductModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateProductVM, Result<int>>(createProductModel, "product/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Product");
            }

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Ürün İşlemleri";
            ViewBag.Title = "Ürün Düzenle";

            //Apiye istek at
            //category/get
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCM.UI.Models.DTOs.Categories;
using SCM.UI.Models.DTOs.Products;
using SCM.UI.Models.RequestModels.Products;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Authorize(Policy = "PurchasingPolicy")]
    [Area("Purchasing")]
    public class ProductController : Controller
    {
        private readonly IRestService _restService;

        public ProductController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpGet("/purchasing/addproduct")]
        public async Task<IActionResult> Create()
        {
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
            if (!ModelState.IsValid)
            {
                return View(createProductModel);
            }

            var response = await _restService.PostAsync<CreateProductVM, Result<int>>(createProductModel, "product/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else 
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Product", new { Area = "Purchasing" });
            }

        }

        [HttpGet("/purchasing/listproducts")]
        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<ProductDTO>>>("product/get");

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

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductVM updateProductModel)
        {
            var response = await _restService.PutAsync<UpdateProductVM, Result<int>>(updateProductModel, $"product/update/{updateProductModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Product", new { Area = "Purchasing" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _restService.DeleteAsync<Result<int>>($"category/delete/{id}");

            return Json(response.Data);

        }
    }
}

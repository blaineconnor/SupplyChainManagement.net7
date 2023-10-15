using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCM.UI.Models.DTOs.Accounts;
using SCM.UI.Models.RequestModels.Accounts;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class LoginController : Controller
    {
        private readonly IRestService _restService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public LoginController(IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM loginModel, [FromQuery] string ReturnUrl)
        {
            //Model doğrulamasını geçemeyen kullanıcıyı buradan tekrar login sayfasına gönder.
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var response = await _restService.PostAsync<LoginVM, Result<TokenDTO>>(loginModel, "account/login", false);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
            }
            else
            {
                var sessionKey = _configuration["Application:SessionKey"];
                _contextAccessor.HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(response.Data.Data));

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home", new { Area = "Manager" }); ;
            }

            return View(loginModel);
        }
    }
}

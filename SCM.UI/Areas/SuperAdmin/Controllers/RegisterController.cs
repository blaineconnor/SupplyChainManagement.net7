using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.UI.Models.RequestModels.Accounts;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;

namespace SCM.UI.Areas.SuperAdmin.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    [Area("SuperAdmin")]
    public class RegisterController : Controller
    {
        private readonly IRestService _restService;

        public RegisterController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpGet("/superadmin/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var response = await _restService.PostAsync<RegisterVM, Result<bool>>(registerVM, "account/register", false);
            return View(registerVM);
        }
    }
}

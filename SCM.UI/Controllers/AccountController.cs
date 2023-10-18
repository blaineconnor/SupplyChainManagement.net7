﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCM.UI.Models.DTOs.Accounts;
using SCM.UI.Models.RequestModels.Accounts;
using SCM.UI.Models.Wrapper;
using SCM.UI.Services.Abstraction;
using System.Net;

namespace SCM.UI.Controllers
{

    public class AccountController : Controller
    {
        private readonly IRestService _restService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public AccountController(IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        [HttpGet("/account/signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM loginModel, [FromQuery] string ReturnUrl)
        {
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

                var role = response.Data.Data.Roles;


                switch (role)
                {
                    case Models.Enumarations.Role.SuperAdmin:
                        return RedirectToAction("Index", "Home", new { Area = "SuperAdmin" });

                    case Models.Enumarations.Role.Admin:
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });

                    case Models.Enumarations.Role.Purchasing:
                        return RedirectToAction("Index", "Home", new { Area = "Purchasing" });

                    case Models.Enumarations.Role.Accounting:
                        return RedirectToAction("Index", "Home", new { Area = "Accounting" });

                    case Models.Enumarations.Role.Supplier:
                        return RedirectToAction("Index", "Home  ", new { Area = "Supplier" });

                    case Models.Enumarations.Role.Employee:
                        return RedirectToAction("Index", "Home", new { Area = "Employee" });

                    case Models.Enumarations.Role.Manager:
                        return RedirectToAction("Index", "Home", new { Area = "Manager" });

                    default:
                        return RedirectToAction("Index", "Home");
                }
            }

            return View(loginModel);
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
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


﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{

    [ApiController]
    [Route("account")]
    [Authorize(Policy = "AdminPolicy")]

    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<int>>> Register(RegisterVM registerVM)
        {
            var result = await _accountService.Register(registerVM);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TokenDTO>>> Login(LoginVM loginVM)
        {
            var result = await _accountService.Login(loginVM);
            return Ok(result);
        }

        [HttpPost("suppregister")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<int>>> RegisterSupplier(RegSuppVM regSuppVM)
        {
            var result = await _accountService.RegisterSupplier(regSuppVM);
            return Ok(result);
        }

        [HttpPost("supplogin")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TokenDTO>>> SupplierLogin(LoginVM loginVM)
        {
            var result = await _accountService.SupplierLogin(loginVM);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<AccountDTO>>> GetByIdAsync(Int64 id)
        {
            var result = await _accountService.GetByIdAsync(id);

            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }        

        [HttpPut("updateAuths")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<int>>> UpdateUserAuths(string userName, UpdateAuthVM updateAuthVM)
        {
            if (userName != updateAuthVM.UserName)
            {
                return BadRequest(new Result<int> { Success = false, Errors = new List<string> { "Kullanıcı adı uyuşmuyor." } });
            }

            var result = await _accountService.UpdateUserAuths(updateAuthVM.UserName, updateAuthVM.Auths);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}



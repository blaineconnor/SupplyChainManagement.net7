using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.RequestModels.Companies;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<List<CompanyDTO>>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("get/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<CompanyDTO>>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(new GetCompanyByIdVM { Id = id });
            return Ok(company);
        }

        [HttpPost("create")]
        //[Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var companyId = await _companyService.CreateCompany(createCompanyVM);
            return Ok(companyId);
        }

        [HttpPut("update/{id:int}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> UpdateCompany(int id, UpdateCompanyVM updateCompanyVM)
        {
            if (id != updateCompanyVM.Id)
            {
                return BadRequest();
            }
            var companyId = await _companyService.UpdateCompany(updateCompanyVM);
            return Ok(companyId);
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<Result<int>>> DeleteCompany(int id)
        {
            var companyId = await _companyService.DeleteCompany(new DeleteCompanyVM { Id = id });
            return Ok(companyId);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Suppliers;
using SCM.Application.Models.RequestModels.Roles;
using SCM.Application.Models.RequestModels.Supplier;
using SCM.Application.Services.Abstractions;
using SCM.Application.Services.Implementations;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("create")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<int>>> CreateSupplier(CreateSupplierVM createSupplierVM)
        {
            var supplierId = await _supplierService.CreateSupplier(createSupplierVM);
            return Ok(supplierId);
        }


        [HttpDelete("delete/{id:int}")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<int>>> DeleteSupplier(int id)
        {
            var supplierId = await _supplierService.DeleteSupplier(new DeleteSupplierVM { Id = id });
            return Ok(supplierId);
        }

        [HttpGet("get")]
        [Authorize(Policy = "PurchasingPolicy")]
        public async Task<ActionResult<Result<List<SupplierDTO>>>> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliers();
            return Ok(suppliers);
        }
    }
}

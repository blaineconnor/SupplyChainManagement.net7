using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCM.Application.Models.DTOs.Invoice;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;

namespace SCM.API.Controllers
{
    [Route("accounting")]
    [ApiController]
    [Authorize(Policy = "AccountingPolicy")]

    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> Fulfillment(CreateInvoiceVM accountingVM)
        {
            var result = await _invoiceService.CreateInvoice(accountingVM);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<InvoiceDTO>>>> GetAllInvoices()
        {
            var item = _invoiceService.GetAllInvoice();
            return Ok(item);
        }
    }
}

using SCM.Application.Models.DTOs.Invoices;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface IInvoiceService
    {
        Task<Result<Int64>> CreateInvoice(CreateInvoiceVM createInvoiceVM);
        Task<Result<List<InvoiceDTO>>> GetAllInvoice();
    }
}

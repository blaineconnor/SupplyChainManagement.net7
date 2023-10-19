using SCM.Application.Models.DTOs.Invoice;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IInvoiceService
    {
        Task<Result<int>> CreateInvoice(CreateInvoiceVM createInvoiceVM);
        Task<Result<List<InvoiceDTO>>> GetAllInvoice();
    }
}

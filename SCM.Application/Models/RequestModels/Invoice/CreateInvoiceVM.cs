using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Invoice
{
    public class CreateInvoiceVM
    {
        public int RequestId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Company Company { get; set; }
    }
}

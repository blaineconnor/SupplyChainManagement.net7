using SCM.UI.Models.DTOs.Companies;

namespace SCM.UI.Models.RequestModels.Invoices
{
    public class CreateInvoiceVM
    {
        public int RequestId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public CompanyDTO Company { get; set; }
    }
}

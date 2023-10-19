using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.RequestModels.Invoices
{
    public class CreateInvoiceVM
    {
        public int RequestId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Company Company { get; set; }
    }
}

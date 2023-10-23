namespace SCM.UI.Models.DTOs.Invoices
{
    public class InvoiceDTO
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public long SupplierId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }


    }
}

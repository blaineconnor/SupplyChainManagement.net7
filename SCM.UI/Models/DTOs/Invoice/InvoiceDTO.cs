namespace SCM.UI.Models.DTOs.Invoice
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int SupplierId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }


    }
}

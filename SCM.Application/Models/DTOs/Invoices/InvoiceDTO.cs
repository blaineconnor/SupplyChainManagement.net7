using System.Numerics;

namespace SCM.Application.Models.DTOs.Invoices
{
    public class InvoiceDTO
    {
        public Int64 Id { get; set; }
        public Int64 RequestId { get; set; }
        public Int64 SupplierId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime InvoiceDate { get; set; }


    }
}

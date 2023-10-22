using System.Numerics;

namespace SCM.Application.Models.DTOs.Invoices
{
    public class InvoiceDTO
    {
        public BigInteger Id { get; set; }
        public BigInteger RequestId { get; set; }
        public BigInteger SupplierId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }


    }
}

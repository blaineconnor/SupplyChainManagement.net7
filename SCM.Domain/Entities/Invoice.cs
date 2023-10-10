using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int SupplierId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }


        public Requests Request { get; set; }
        public Supplier Supplier { get; set; }
    }
}

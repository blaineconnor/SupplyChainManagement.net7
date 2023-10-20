using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public int RequestId { get; set; }
        public int SupplierId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Company Company { get; set; }

        public User User { get; set; }
        public Requests Request { get; set; }
    }
}

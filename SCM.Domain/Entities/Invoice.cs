using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public Int64 RequestId { get; set; }
        public Int64? OfferId { get; set; }
        public string? SupplierName { get; set; }
        public Int64? ApproverId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime InvoiceDate { get; set; }

        public virtual Request Request { get; set; }
    }
}

using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Invoice : AuditableEntity
    {
        public BigInteger RequestId { get; set; }
        public BigInteger SupplierId { get; set; }
        public string SupplierName { get; set; }
        public BigInteger ApproverId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}

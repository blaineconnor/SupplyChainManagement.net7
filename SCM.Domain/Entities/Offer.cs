using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public Offer()
        {
            Approves = new List<Approves>();
        }

        public BigInteger RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }

        public BigInteger SupplierId { get; set; }
        public OfferStatus Status { get; set; }

        public ICollection<Approves> Approves { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Request Request { get; set; }


        public enum OfferStatus
        {
            pending = 1,
            approved = 2,
            rejected = 3
        }
    }
}

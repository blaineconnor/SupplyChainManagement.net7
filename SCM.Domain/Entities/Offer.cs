using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public Offer()
        {
            Approves = new List<Approves>();
            Requests = new HashSet<Request>();
        }

        public Int64 RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public Int64 SupplierId { get; set; }
        public OfferStatus Status { get; set; }

        //NavigationProperty
        public ICollection<Approves> Approves { get; set; }
        public IEnumerable<Request> Requests { get; set; }
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

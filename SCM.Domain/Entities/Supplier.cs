using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Supplier : AuditableEntity
    {
        public Supplier()
        {
            Offers = new HashSet<Offer>();
        }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Account Account { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public virtual Authorization Auth { get; set; }
    }
}

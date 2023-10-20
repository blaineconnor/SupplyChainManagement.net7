using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class RequestDetail : AuditableEntity
    {
        public BigInteger RequestId { get; set; }
        public BigInteger ProductId { get; set; }
        public double Quantity { get; set; }

        //NavigationProperty
        public virtual Request Request { get; set; }
        public virtual Product Product { get; set; }
    }
}

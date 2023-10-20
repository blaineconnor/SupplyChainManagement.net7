using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Product()
        {
            Details = new HashSet<RequestDetail>();
        }

        public BigInteger CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public Category Categories { get; set; }
        public virtual IEnumerable<RequestDetail> Details { get; set; }
    }
}

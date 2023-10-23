using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Product : AuditableEntity
    {   

        public Int64 CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public Category Categories { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
    }
}

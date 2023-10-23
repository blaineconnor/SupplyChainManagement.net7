using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Message : AuditableEntity
    {
        public Int64 UserId { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Employee User { get; set; }
    }
}

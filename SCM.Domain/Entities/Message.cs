using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Message : AuditableEntity
    {
        public Int64 UserId { get; set; }
        public string Description { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public Employee Employee { get; set; }
    }
}

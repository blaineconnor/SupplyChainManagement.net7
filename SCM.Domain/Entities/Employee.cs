using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 DepartmentId { get; set; }
            

        public virtual Account Account { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Approves> Approves { get; set; }
        public IEnumerable<Message> messages { get; set; }

        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }
        public virtual Message Message { get; set; }
    }
}

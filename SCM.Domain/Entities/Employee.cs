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
        public BigInteger CompanyId { get; set; }
        public BigInteger DepartmentId { get; set; }


        public virtual Account Account { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Approves> Approves { get; set; }
        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }
    }
}

using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Department : AuditableEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Int64 CompanyId { get; set; }


        //NavigationProperty
        public virtual Company Company { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}

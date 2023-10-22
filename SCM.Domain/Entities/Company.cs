using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Company: AuditableEntity
    {
        public Company()
        {
            Departments = new HashSet<Department>();
            Employees = new HashSet<Employee>();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //NavigationProperty
        public virtual IEnumerable<Department> Departments { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}

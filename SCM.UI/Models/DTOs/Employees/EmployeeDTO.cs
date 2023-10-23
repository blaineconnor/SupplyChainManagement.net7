using SCM.UI.Models.DTOs.Companies;
using SCM.UI.Models.DTOs.Departments;

namespace SCM.UI.Models.DTOs.Employees
{
    public class EmployeeDTO
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public CompanyDTO Company { get; set; }
        public DepartmentDTO Department { get; set; }

    }
}

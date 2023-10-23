using SCM.UI.Models.DTOs.Employees;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public long DepartmentId { get; set; }


        //NavigationProperty
        public Authorizations Authorization { get; set; }
        public EmployeeDTO User { get; set; }
    }
}

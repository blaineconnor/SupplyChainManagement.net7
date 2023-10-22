using SCM.Application.Models.DTOs.Employees;
using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Application.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public BigInteger UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public string RoleName { get; set; }
        public BigInteger RoleId { get; set; }
        public string CompanyName { get; set; }
        public BigInteger CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public BigInteger DepartmentId { get; set; }


        //NavigationProperty
        public Authorization Authorization { get; set; }
        public Role Roles { get; set; }
        public EmployeeDTO User { get; set; }
    }
}

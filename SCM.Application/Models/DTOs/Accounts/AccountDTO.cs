using SCM.Application.Models.DTOs.Employees;
using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Application.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public string CompanyName { get; set; }
        public Int64 CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public Int64 DepartmentId { get; set; }


        //NavigationProperty
        public Authorization Authorization { get; set; }
        public EmployeeDTO User { get; set; }
    }
}

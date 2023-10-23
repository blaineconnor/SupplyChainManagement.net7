using SCM.UI.Models.DTOs.Employees;
using SCM.UI.Models.DTOs.Suppliers;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public string CompanyName { get; set; }
        public Int64 CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public Int64 DepartmentId { get; set; }

        //Employee
        public Int64 UserId { get; set; }
        public string UserName { get; set; }

        //Supplier
        public Int64 SupplierId { get; set; }
        public string SupplierName { get; set; }



        //NavigationProperty
        public Authorizations Authorization { get; set; }
        public SupplierDTO Supplier { get; set; }
        public EmployeeDTO User { get; set; }
    }
}

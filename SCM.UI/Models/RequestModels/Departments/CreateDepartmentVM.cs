namespace SCM.UI.Models.RequestModels.Departments
{
    public class CreateDepartmentVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long CompanyId { get; set; }
    }
}

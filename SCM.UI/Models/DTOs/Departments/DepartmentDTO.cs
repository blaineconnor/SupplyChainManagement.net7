namespace SCM.UI.Models.DTOs.Departments
{
    public class DepartmentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

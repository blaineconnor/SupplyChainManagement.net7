using System.Numerics;

namespace SCM.Application.Models.DTOs.Departments
{
    public class DepartmentDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

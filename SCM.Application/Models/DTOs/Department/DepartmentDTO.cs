using System.Numerics;

namespace SCM.Application.Models.DTOs.Department
{
    public class DepartmentDTO
    {
        public BigInteger Id { get; set; }
        public string Name { get; set; }
        public BigInteger CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}

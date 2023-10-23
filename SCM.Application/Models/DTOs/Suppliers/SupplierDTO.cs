using System.Numerics;

namespace SCM.Application.Models.DTOs.Suppliers
{
    public class SupplierDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Int64 RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

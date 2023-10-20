using System.Numerics;

namespace SCM.Application.Models.DTOs.Supplier
{
    public class SupplierDTO
    {
        public BigInteger Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public BigInteger RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

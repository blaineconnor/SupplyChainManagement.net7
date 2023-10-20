using System.Numerics;

namespace SCM.Application.Models.DTOs.Company
{
    public class CompanyDTO
    {
        public BigInteger Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

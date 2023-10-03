using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Account
{
    public class TokenDTO
    {
        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace SCM.Domain.Entities
{
    public class Role : IdentityRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime DateCreated { get; set; }

        public Account Account { get; set; }
    }
}

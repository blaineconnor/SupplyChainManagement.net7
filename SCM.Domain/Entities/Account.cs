using Microsoft.AspNetCore.Identity;
using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public DateTime? LastUserId { get; set; }
        public Roles Roles { get; set; }
    }

    public class Roles : IdentityRole<int>
    {
        public DateTime DateCreated { get; set; }
    }
}

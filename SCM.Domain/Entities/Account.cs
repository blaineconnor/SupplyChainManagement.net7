using Microsoft.AspNetCore.Identity;
using SCM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public DateTime? LastUserId { get; set; }
        public Role Roles { get; set; } 
        public User Users { get; set; }
    }
}

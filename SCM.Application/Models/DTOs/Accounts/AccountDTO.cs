using SCM.Application.Models.DTOs.Supplier;
using SCM.Application.Models.DTOs.Users;
using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public Role Roles { get; set; }

        public SupplierDTO Supplier { get; set; }
        public UserDTO User { get; set; }
    }
}

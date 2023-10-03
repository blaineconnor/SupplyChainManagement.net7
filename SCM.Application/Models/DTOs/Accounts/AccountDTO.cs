using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Account
{
    public class AccountDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public DateTime? LastUserIP { get; set; }
        public Roles Roles { get; set; }
    }
}

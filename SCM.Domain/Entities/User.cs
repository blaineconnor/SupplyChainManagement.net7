using Microsoft.AspNetCore.Identity;

namespace SCM.Domain.Entities
{
    public class User : IdentityUser
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birtdate { get; set; }


        public Account Account { get; set; }
        public ICollection<Requests> Requests { get; set; }
    }
}

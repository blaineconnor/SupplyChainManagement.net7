using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Users
{
    public class UserDTO
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public Company Company { get; set; }
        public Department Department { get; set; }

    }
}

using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Message : AuditableEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }

        public User User { get; set; }
    }
}

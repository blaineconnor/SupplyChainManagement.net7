using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Role : AuditableEntity
    {
        public string RoleName { get; set; }
    }
}

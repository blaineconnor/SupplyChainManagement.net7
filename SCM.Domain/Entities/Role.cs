using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Role : AuditableEntity
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
            Suppliers = new HashSet<Supplier>();
        }
        public string RoleName { get; set; }
        public virtual IEnumerable<Account> Accounts { get; set; }
        public virtual IEnumerable<Supplier> Suppliers { get; set; }


    }
}

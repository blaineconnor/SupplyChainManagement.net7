using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Department : AuditableEntity
    {
        public Department()
        {
            Account = new HashSet<Account>();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public BigInteger CompanyId { get; set; }


        //NavigationProperty
        public virtual Company Company { get; set; }
        public virtual IEnumerable<Account> Account { get; set; }
    }
}

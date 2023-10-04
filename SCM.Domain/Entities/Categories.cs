using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Categories : AuditableEntity
    {
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}

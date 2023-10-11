using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public Categories Categories { get; set; }
        public ICollection<Approves> Approves { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}

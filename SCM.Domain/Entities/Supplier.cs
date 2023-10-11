using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Supplier : AuditableEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }


        //Navigation Properties
        public Account Account { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}

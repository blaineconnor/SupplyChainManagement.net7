using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class RequestDetail : AuditableEntity
    {
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string RequestDescription { get; set; }
        public Requests Request { get; set; }
        public Product Product { get; set; }
    }
}

using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Offers
{
    public class OfferDTO
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public long SupplierId { get; set; }
        public DateTime OfferDate { get; set; }
        public OfferStatus Status { get; set; }
    }

}

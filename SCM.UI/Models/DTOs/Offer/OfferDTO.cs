namespace SCM.UI.Models.DTOs.Offer
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public DateTime OfferDate { get; set; }
    }

}

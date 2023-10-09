namespace SCM.Application.Models.DTOs.Offer
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

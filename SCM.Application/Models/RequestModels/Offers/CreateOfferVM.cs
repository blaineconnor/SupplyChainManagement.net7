namespace SCM.Application.Models.RequestModels.Offers
{
    public class CreateOfferVM
    {
        public int RequestId { get; set; }

        public string SupplierName { get; set; }

        public decimal Amount { get; set; }

        public DateTime OfferDate { get; set; }
    }
}

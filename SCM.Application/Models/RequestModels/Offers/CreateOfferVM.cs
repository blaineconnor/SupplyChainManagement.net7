using System.Numerics;

namespace SCM.Application.Models.RequestModels.Offers
{
    public class CreateOfferVM
    {
        public Int64 RequestId { get; set; }
        public string SupplierName { get; set; }

        public decimal Amount { get; set; }

    }
}

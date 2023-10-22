using System.Numerics;
using static SCM.Domain.Entities.Offer;

namespace SCM.Application.Models.DTOs.Offers
{
    public class OfferDTO
    {
        public BigInteger Id { get; set; }
        public BigInteger RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public BigInteger SupplierId { get; set; }
        public DateTime OfferDate { get; set; }
        public OfferStatus Status { get; set; }
    }

}

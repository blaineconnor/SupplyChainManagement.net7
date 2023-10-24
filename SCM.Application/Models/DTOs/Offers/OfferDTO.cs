using System.Numerics;
using static SCM.Domain.Entities.Offer;

namespace SCM.Application.Models.DTOs.Offers
{
    public class OfferDTO
    {
        public Int64 Id { get; set; }
        public Int64 RequestId { get; set; }
        public decimal Amount { get; set; }
        public string? SupplierName { get; set; }
        public Int64? SupplierId { get; set; }
        public DateTime OfferDate { get; set; }
        public OfferStatus Status { get; set; }
    }

}

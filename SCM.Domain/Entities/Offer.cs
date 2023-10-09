﻿using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public string SupplierName { get; set; }
        public DateTime OfferDate { get; set; }
    }
}

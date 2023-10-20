using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Request : AuditableEntity
    {
        public Request()
        {
            Invoices = new List<Invoice>();
            Offers = new List<Offer>();
            Details = new HashSet<RequestDetail>();
        }

        public BigInteger ApproverId { get; set; }
        public string ApproverName { get; set; }
        public BigInteger OfferId { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public decimal Amount { get; set; }
        public short HowMany { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }


        //NavigationProperties
        public virtual Employee User { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual IEnumerable<RequestDetail> Details { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public Offer Offer { get; set; }
    }

    public enum RequestStatus
    {
        Pending = 1,             // İlk talep oluşturuldu.
        ManagerApproved = 2,     // Manager onayladı, teklif almaya gönderildi.
        PurchasingApproved = 3,  //  Purchasing onayladı, Muhasebeye gönderildi.
        AdminApproved = 4,       // Admin onayladı, Muhasebeye gönderildi.
        SuperAdminApproved = 5,  // SuperAdmin onayladı, Muhasebeye gönderildi.
        Completed = 6,           // Muhasebe faturalandırdı, tamamlandı.
        Rejected = 7,             // Herhangi bir aşamada reddedildi.
        OfferReceived = 8       //Teklif alındı.
    }
}

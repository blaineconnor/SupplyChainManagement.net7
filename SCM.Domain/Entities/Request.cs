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
            Approves = new List<Approves>();
        }

        public Int64 ApproverId { get; set; }
        public string ApproverName { get; set; }
        public Int64 OfferId { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 UserId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public decimal Amount { get; set; }
        public short HowMany { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }


        //NavigationProperties
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public virtual IEnumerable<Approves> Approves { get; set; }
        public Approves approves { get; set; }
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

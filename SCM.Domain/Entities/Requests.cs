using SCM.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SCM.Domain.Entities
{
    public class Requests : AuditableEntity
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public RequestStatus Status { get; set; }
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }

        
        //NavigationProperties
        public User User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Approves> Approves { get; set; }
        
    }

    public enum RequestStatus
    {
        Pending = 1,             // İlk talep oluşturuldu.
        ManagerApproved = 2,     // Manager onayladı, Purchasing'e gönderildi.
        PurchasingApproved = 3,  // Fiyat Alındı Purchasing onayladı.
        AdminApproved = 4,       // Admin onayladı, Muhasebeye gönderildi.
        SuperAdminApproved = 5,  // SuperAdmin onayladı, Muhasebeye gönderildi.
        Completed = 6,           // Muhasebe faturalandırdı, tamamlandı.
        Rejected = 7,             // Herhangi bir aşamada reddedildi.
        OfferReceived = 8       //Teklif alındı.
    }
}

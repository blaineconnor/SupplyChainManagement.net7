namespace SCM.UI.Models
{
    public class Enumarations
    {
        public enum Role
        {
            User = 1,
            Supplier = 2,
            Employee = 3,
            Accounting = 4,
            Manager = 5,
            Purchasing = 6,
            Admin = 50,
            SuperAdmin = 100,
        }
        public enum RequestStatus
        {
            Pending = 1,             // İlk talep oluşturuldu
            ManagerApproved = 2,     // Manager onayladı, Purchasing'e gönderildi
            PurchasingApproved = 3,  // Fiyat Alındı ve Purchasing fiyatı seçti, Purchasing onayladı ya da Admin veya SuperAdmin'e gönderildi
            AdminApproved = 4,       // Admin onayladı, Muhasebeye gönderildi
            SuperAdminApproved = 5,  // SuperAdmin onayladı, Muhasebeye gönderildi
            Completed = 6,           // Muhasebe faturalandırdı, tamamlandı
            Rejected = 7,             // Herhangi bir aşamada reddedildi
            OfferReceived = 8
        }
    }
}

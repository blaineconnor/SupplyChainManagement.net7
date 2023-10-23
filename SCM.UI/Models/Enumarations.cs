namespace SCM.UI.Models
{
    public class Enumarations
    {
        public enum Authorizations
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
        //public enum Company
        //{
        //    Technology = 1,
        //    Energy = 2,
        //    Finance = 3,
        //    Jewellery = 4,
        //    Investment = 5,
        //    Automotive = 6,
        //    Health = 7,
        //    RealEstate = 8,
        //    Refinery = 9,
        //    Undetermined = 10,
        //}

        public enum OfferStatus
        {
            pending = 1,
            approved = 2,
            reject = 3,
        }
    }
}

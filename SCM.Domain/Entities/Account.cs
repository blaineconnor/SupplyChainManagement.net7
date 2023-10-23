using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public Account()
        {
           Requests = new HashSet<Request>();
        }

        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }   

        //NavigationProperties
        public Authorization Authorization { get; set; }
        public Employee Employee { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }        
    }

    public enum Authorization
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
}

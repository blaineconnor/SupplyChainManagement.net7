﻿using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public Role Roles { get; set; } 

        public Supplier Suppliers { get; set; }
        public User User { get; set; }
    }

    public enum Role
    {
        Admin = 1,
        Purchasing = 2,
        Accounting = 3,
        User = 4,
        SuperAdmin = 5,
        Employee = 6,
        Offer = 7,
        Manager = 8,
        Supplier = 9,
    }
}

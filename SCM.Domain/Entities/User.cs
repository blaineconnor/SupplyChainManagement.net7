﻿using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }


        public Account Account { get; set; }
        public ICollection<Requests> Requests { get; set; }
        public ICollection<Approves> Approves { get; set; }
    }
}

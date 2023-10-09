﻿using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Requests : AuditableEntity
    {
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public int Amount { get; set; }

        public ICollection<RequestDetail> RequestDetails { get; set; }
        public ICollection<Approves> Approves { get; set; }
        public bool IsApproved { get; set; }
    }

    public enum RequestStatus
    {
        RequestCreated = 1,
        Pending = 2,
        RequestDelivering = 3,
        Complated = 4,
    }
}

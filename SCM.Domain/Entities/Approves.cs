using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Approves : AuditableEntity
    {
        public int RequestId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Comment { get; set; }
        public string ApprovedBy { get; set; }
        public string RequestedBy { get; set; }


        public Offer Offer { get; set; }
        public Requests Requests { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}

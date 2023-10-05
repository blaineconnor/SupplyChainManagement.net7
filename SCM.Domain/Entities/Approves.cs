using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Approves : AuditableEntity
    {
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }

        public Requests Requests { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}

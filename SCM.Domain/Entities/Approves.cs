using SCM.Domain.Common;

namespace SCM.Domain.Entities
{
    public class Approves : AuditableEntity
    {
        public int ApproveId { get; set; }
        public RequestStatus Status { get; set; }

        public RequestStatus RequestStatus { get; set; }
    }
}

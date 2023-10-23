using SCM.Domain.Common;
using System.Numerics;

namespace SCM.Domain.Entities
{
    public class Approves : AuditableEntity
    {
        public Approves()
        {
            Requests=new List<Request>();
        }

        public Int64 RequestId { get; set; }
        public decimal Amount { get; set; }
        public Int64 ApproveId { get; set; }
        public RequestStatus Status { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}

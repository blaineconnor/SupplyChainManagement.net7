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

        public BigInteger RequestId { get; set; }
        public decimal Amount { get; set; }
        public BigInteger ApproveId { get; set; }
        public RequestStatus Status { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}

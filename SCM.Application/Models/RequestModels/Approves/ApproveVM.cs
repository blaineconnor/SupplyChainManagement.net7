using System.Numerics;

namespace SCM.Application.Models.RequestModels.Approves
{
    public class ApproveVM
    {
        public Int64 RequestId { get; set; }
        public bool IsApproved { get; set; }
    }
}

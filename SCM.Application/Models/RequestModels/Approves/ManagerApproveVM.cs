using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Application.Models.RequestModels.Approves
{
    public class ManagerApproveVM
    {
        public BigInteger RequestId { get; set; }
        public bool IsApproved { get; set; }
    }
}

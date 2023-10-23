using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Application.Models.DTOs.Approves
{
    public class ApproveDTO
    {
        public Int64 Id { get; set; }
        public Int64 RequestId { get; set; }
        public bool IsApproved { get; set; }
        public decimal ApprovedAmount { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string RequestedBy { get; set; }
    }
}

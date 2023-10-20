using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Approves
{
    public class ApproveDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
        public decimal ApprovedAmount { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string RequestedBy { get; set; }
    }
}

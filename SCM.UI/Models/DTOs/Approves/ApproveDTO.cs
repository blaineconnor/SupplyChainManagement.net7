using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Approves
{
    public class ApproveDTO
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public bool IsApproved { get; set; }
        public decimal ApprovedAmount { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string RequestedBy { get; set; }
    }
}

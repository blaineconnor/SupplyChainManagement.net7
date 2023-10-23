using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Requests
{
    public class RequestDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public decimal Amount { get; set; }
        public short HowMany { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }
    }
}

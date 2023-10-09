namespace SCM.Application.Models.RequestModels.Approves
{
    public class ApproveVM
    {
        public int RequestId { get; set; }
        public string ApproverRole { get; set; } // Manager, Admin, Purchasing, vs.
        public bool IsApproved { get; set; }
        public decimal ApprovedAmount { get; set; }
    }
}

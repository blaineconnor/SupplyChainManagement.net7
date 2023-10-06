namespace SCM.Application.Models.RequestModels.Approves
{
    public class ApproveVM
    {
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
        public int Amount { get; set; }
    }
}

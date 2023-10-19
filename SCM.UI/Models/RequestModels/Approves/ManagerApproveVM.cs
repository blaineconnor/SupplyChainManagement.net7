using SCM.Domain.Entities;

namespace SCM.UI.Models.RequestModels.Approves
{
    public class ManagerApproveVM
    {
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
    }
}

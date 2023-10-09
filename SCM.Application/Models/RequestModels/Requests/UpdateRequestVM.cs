using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public int Amount { get; set; }
    }
}

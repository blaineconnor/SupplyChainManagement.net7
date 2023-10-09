using SCM.Application.Models.RequestModels.RequestDetails;
using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class CreateRequestVM
    {
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public int Amount { get; set; }
        public List<CreateRequestDetailVM> RequestDetails { get; set; }

    }
}

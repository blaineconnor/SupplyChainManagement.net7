using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public int? RequestId { get; set; }
        public RequestStatus? StatusId { get; set; }
    }
}

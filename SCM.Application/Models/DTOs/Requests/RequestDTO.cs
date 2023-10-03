using SCM.Application.Models.DTOs.RequestDetails;
using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Requests
{
    public class RequestDTO
    {
        public DateTime? RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public ICollection<RequestDetailDTO> RequestDetails { get; set; }
    }
}

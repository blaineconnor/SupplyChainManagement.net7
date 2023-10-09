using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Requests
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public int Amount { get; set; }
        public bool IsApproved { get; set; }
    }
}

using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Application.Models.DTOs.Requests
{
    public class RequestDTO
    {
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public decimal Amount { get; set; }
        public short HowMany { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }
    }
}

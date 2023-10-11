using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int HowMany { get; set; }
    }
}

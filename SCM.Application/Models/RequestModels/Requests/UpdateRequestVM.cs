using System.Numerics;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public Int64 RequestId { get; set; }
        public Int64 UserId { get; set; }
        public int HowMany { get; set; }
    }
}

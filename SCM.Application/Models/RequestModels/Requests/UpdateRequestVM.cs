using System.Numerics;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public BigInteger RequestId { get; set; }
        public BigInteger UserId { get; set; }
        public int HowMany { get; set; }
    }
}

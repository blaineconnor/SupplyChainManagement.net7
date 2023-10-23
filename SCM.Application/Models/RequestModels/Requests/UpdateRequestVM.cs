using System.Numerics;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class UpdateRequestVM
    {
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public int HowMany { get; set; }
    }
}

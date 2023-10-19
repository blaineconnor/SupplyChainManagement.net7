using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Requests
{
    public class CreateRequestVM
    {
        public int HowMany { get; set; }
        public string Description { get; set; }
    }
}

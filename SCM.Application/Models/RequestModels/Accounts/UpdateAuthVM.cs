using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Accounts
{
    public class UpdateAuthVM
    {
        public string UserName { get; set; }
        public Authorization Auths { get; set; }
    }
}

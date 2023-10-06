using SCM.Domain.Entities;

namespace SCM.Application.Models.RequestModels.Accounts
{
    public class UpdateUserVM
    {
        public string UserName { get; set; }
        public Role Roles { get; set; }
    }
}

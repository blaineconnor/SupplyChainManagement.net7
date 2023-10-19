using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.RequestModels.Accounts
{
    public class UpdateRoleVM
    {
        public string UserName { get; set; }
        public Role Roles { get; set; }
    }
}

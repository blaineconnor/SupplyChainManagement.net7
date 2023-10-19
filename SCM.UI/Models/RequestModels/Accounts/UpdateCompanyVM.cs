using SCM.Domain.Entities;

namespace SCM.UI.Models.RequestModels.Accounts
{
    public class UpdateCompanyVM
    {
        public string UserName { get; set; }
        public Company Company { get; set; }
    }
}

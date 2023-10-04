using System.ComponentModel.DataAnnotations;

namespace SCM.Application.Models.RequestModels.Accounts
{
    public class LoginVM
    {        
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Accounts
{
    public class TokenDTO
    {
        public Authorizations Auth { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}

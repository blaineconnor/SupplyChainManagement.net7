using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Application.Models.RequestModels.Accounts
{
    public class RegSuppVM
    {
        public string SupplierName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

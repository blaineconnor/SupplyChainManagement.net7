﻿using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.RequestModels.Accounts
{
    public class UpdateAuthVM
    {
        public string UserName { get; set; }
        public Authorizations Auths { get; set; }
    }
}

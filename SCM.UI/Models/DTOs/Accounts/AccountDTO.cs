﻿using SCM.UI.Models.DTOs.Users;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Models.DTOs.Accounts
{
    public class AccountDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastUserLogin { get; set; }
        public string LastUserIP { get; set; }
        public Role Roles { get; set; }

        public UserDTO User { get; set; }
    }
}
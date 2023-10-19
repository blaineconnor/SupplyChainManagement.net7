﻿using SCM.Domain.Entities;

namespace SCM.UI.Models.DTOs.Accounts
{
    public class TokenDTO
    {
        public Role Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}

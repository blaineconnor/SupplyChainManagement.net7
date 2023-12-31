﻿using SCM.Domain.Entities;

namespace SCM.Application.Models.DTOs.Accounts
{
    public class TokenDTO
    {
        public Authorization Auth { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}

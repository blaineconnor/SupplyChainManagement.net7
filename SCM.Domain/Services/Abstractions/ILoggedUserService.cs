﻿using SCM.Domain.Entities;

namespace SCM.Domain.Services.Abstractions
{
    public interface ILoggedUserService
    {
        int? UserId { get;}
        Roles? Roles { get; }
        string UserName { get; }
    }
}
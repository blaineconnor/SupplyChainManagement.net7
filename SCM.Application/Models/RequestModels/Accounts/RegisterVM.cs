﻿namespace SCM.Application.Models.RequestModels.Accounts
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public object Email { get; internal set; }
    }
}

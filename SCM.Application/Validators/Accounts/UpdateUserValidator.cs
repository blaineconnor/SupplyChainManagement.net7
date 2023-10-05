using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserVM>
    {
        public UpdateUserValidator() 
        {
            RuleFor(x => x.Roles)
                .NotEmpty()
                .WithMessage("Rol bilgisini seçmeden giriş yapamazsınız.");
        }
    }
}

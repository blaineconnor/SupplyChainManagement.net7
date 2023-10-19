using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class UpdateRoleValidator: AbstractValidator<UpdateRoleVM>
    {
        public UpdateRoleValidator() 
        {
            RuleFor(x => x.Roles)
                .NotEmpty()
                .WithMessage("Rol bilgisini seçmeden giriş yapamazsınız.");            
        }
    }
}

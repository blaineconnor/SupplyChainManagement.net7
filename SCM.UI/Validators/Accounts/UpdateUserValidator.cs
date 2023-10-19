using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
{
    public class UpdateUserValidator : AbstractValidator<UpdateRoleVM>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Roles)
                .NotEmpty()
                .WithMessage("Rol bilgisini seçmeden giriş yapamazsınız.");
        }
    }
}

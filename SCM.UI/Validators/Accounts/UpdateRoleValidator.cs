using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleVM>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Roles)
                .NotEmpty()
                .WithMessage("Rol bilgisini seçmeden giriş yapamazsınız.");
        }
    }
}

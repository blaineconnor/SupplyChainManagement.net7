using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
{
    public class UpdateRoleValidator : AbstractValidator<UpdateAuthVM>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Auths)
                .NotEmpty()
                .WithMessage("Yetki bilgisini seçmeden giriş yapamazsınız.");
        }
    }
}

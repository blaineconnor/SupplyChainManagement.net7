using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class UpdateAuthValidator : AbstractValidator<UpdateAuthVM>
    {
        public UpdateAuthValidator()
        {
            RuleFor(x => x.Auths)
                .NotEmpty()
                .WithMessage("Rol bilgisi boş olamaz.");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı bilgisi boş olamaz.");

        }
    }
}

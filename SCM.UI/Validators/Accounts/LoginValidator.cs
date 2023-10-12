using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz.")
               .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola bilgisi boş olamaz.")
                .MinimumLength(8).WithMessage("Parola bilgisi en az 8 karakter olabilir.")
                .MaximumLength(16).WithMessage("Parola en fazla 16 karakter olabilir.");
        }
    }
}

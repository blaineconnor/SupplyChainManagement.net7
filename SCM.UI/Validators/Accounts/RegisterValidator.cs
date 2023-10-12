using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Ad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Soyad bilgisi 30 karakterden büyük olamaz.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Eposta bilgisi boş olamaz.");

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
               .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MaximumLength(10).WithMessage("Parola en fazla 10 karakter olabilir.");

            RuleFor(x => x.PasswordAgain)
                .NotEmpty().WithMessage("Parola tekrar bilgisi boş olamaz.")
                .MaximumLength(10).WithMessage("Parola tekrar bilgisi 10 karakter olabilir.");

            RuleFor(x => x.Password)
                .Equal(x => x.PasswordAgain)
                .When(x => !string.IsNullOrWhiteSpace(x.Password))
                .WithMessage("Parola ve parola tekrar bilgisi eşleşmiyor.");
        }
    }
}

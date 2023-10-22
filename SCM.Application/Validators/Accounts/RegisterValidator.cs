using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.IdentityNumber)
                .MaximumLength(11).MinimumLength(11).WithMessage("Kimlik bilgisi 11 karakterden oluşmalıdır.")                
                .NotEmpty().WithMessage("Kimlik bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Kimlik bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Ad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Soyad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Eposta bilgisi boş olamaz.");
                
            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
               .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MinimumLength(8).WithMessage("Parola en az 8 karakter olabilir.")
                .MaximumLength(16).WithMessage("Parola en fazla 16 karakter olabilir.");

            RuleFor(x => x.PasswordAgain)
                .NotEmpty().WithMessage("Parola tekrar bilgisi boş olamaz.")
                .MinimumLength(8).WithMessage("Parola tekrar bilgisi en az 8 karakter olabilir.")
                .MaximumLength(10).WithMessage("Parola tekrar bilgisi 16 karakter olabilir.");

            RuleFor(x => x.Password)
                .Equal(x => x.PasswordAgain)
                .When(x => !String.IsNullOrWhiteSpace(x.Password))
                .WithMessage("Parola ve parola tekrar bilgisi eşleşmiyor.");
        }
    }
}

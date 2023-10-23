using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class RegSuppValidator : AbstractValidator<RegSuppVM>
    {
        public RegSuppValidator()
        {
            RuleFor(x=>x.SupplierName)
                .NotEmpty()
                .WithMessage("Tedarikçi ismi boş bırakılamaz.");

            RuleFor(x => x.Email)
               .EmailAddress()
               .NotEmpty().WithMessage("Eposta bilgisi boş olamaz.");

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
               .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olabilir.");

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

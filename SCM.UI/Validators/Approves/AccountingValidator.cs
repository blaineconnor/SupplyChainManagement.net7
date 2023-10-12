using FluentValidation;
using SCM.UI.Models.RequestModels.Approves;

namespace SCM.UI.Validators.Approves
{
    public class AccountingValidator : AbstractValidator<AccountingVM>
    {
        public AccountingValidator()
        {
            RuleFor(x => x.RequestId)
              .NotEmpty().WithMessage("Talep kimliği boş olamaz.")
              .GreaterThan(0).WithMessage("Geçerli bir talep kimliği belirtmelisiniz.");
        }
    }
}

using FluentValidation;
using SCM.UI.Models.RequestModels.Approves;

namespace SCM.UI.Validators.Approves
{
    public class ApproveValidator : AbstractValidator<ManagerApproveVM>
    {
        public ApproveValidator()
        {
            RuleFor(x => x.RequestId)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir talep kimliği belirtmelisiniz.");

            RuleFor(x => x.IsApproved)
                .NotEmpty()
                .WithMessage("Seçim yapmadan giriş yapamazsınız.");

            RuleFor(x => x.IsApproved)
                .NotEmpty()
                .When(x => x.IsApproved == true)
                .WithMessage("Talep Onaylanmıştır.");

            RuleFor(x => x.IsApproved)
                .NotEmpty()
                .When(x => x.IsApproved == false)
                .WithMessage("Talep Reddedilmiştir.");
        }
    }
}

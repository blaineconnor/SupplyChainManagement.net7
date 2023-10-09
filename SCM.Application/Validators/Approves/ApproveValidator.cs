using FluentValidation;
using SCM.Application.Models.RequestModels.Approves;

namespace SCM.Application.Validators.Approves
{
    public class ApproveValidator : AbstractValidator<ApproveVM>
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

            RuleFor(x => x.RequestId)
                .NotEmpty()
                .WithMessage("Talep numarası boş olamaz.");
        }
    }
}

using FluentValidation;
using SCM.Application.Models.RequestModels.Approves;

namespace SCM.Application.Validators.Approves
{
    public class ApproveValidator : AbstractValidator<ApproveVM>
    {
        public ApproveValidator()
        {
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

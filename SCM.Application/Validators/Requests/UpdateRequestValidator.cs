using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestVM>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.RequestId)
                            .NotEmpty().WithMessage("Talep numarası boş olamaz.")
                            .GreaterThan(0).WithMessage("Talep numarası sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Talep durumu boş olamaz.")
                .IsInEnum().WithMessage("Talep durumu geçerli bir değer değildir.");
        }
    }
}

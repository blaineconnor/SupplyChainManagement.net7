using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class DeleteRequestValidator : AbstractValidator<DeleteRequestVM>
    {
        public DeleteRequestValidator()
        {
            RuleFor(x => x.RequestId)
               .NotEmpty().WithMessage("Talep numarası boş olamaz.")
               .GreaterThan(0).WithMessage("Talep numarası sıfırdan büyük bir sayı olmalıdır.");
        }
    }
}

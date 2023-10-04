using FluentValidation;
using SCM.Application.Models.RequestModels.RequestDetails;

namespace SCM.Application.Validators.RequestDetails
{
    public class DeleteRequestDetailValidator : AbstractValidator<DeleteRequestDetailVM>
    {
        public DeleteRequestDetailValidator()
        {
            RuleFor(x => x.RequestDetailId)
               .NotEmpty().WithMessage("Talep detay numarası boş olamaz.")
               .GreaterThan(0).WithMessage("Talep detay numarası sıfırdan büyük olmalıdır.");
        }
    }
}

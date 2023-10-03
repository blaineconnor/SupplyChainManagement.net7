using FluentValidation;
using SCM.Application.Models.RequestModels.RequestDetails;

namespace SCM.Application.Validators.RequestDetails
{
    public class GetRequestDetailsByRequestIdValidator : AbstractValidator<GetRequestDetailsByRequestIdVM>
    {
        public GetRequestDetailsByRequestIdValidator()
        {
            RuleFor(x => x.RequestId)
                .NotEmpty().WithMessage("Sipariş numarası boş olamaz.")
                .GreaterThan(0).WithMessage("Sipariş numarası sıfırdan büyük olmalıdır.");
        }
    }
}

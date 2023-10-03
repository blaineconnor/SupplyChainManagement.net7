using FluentValidation;
using SCM.Application.Models.RequestModels.RequestDetails;

namespace SCM.Application.Validators.RequestDetails
{
    public class CreateRequestDetailValidator : AbstractValidator<CreateRequestDetailVM>
    {
        public CreateRequestDetailValidator()
        {
            RuleFor(x => x.RequestId)
               .NotEmpty().WithMessage("Talep numarası boş olamaz.")
               .GreaterThan(0).WithMessage("Talep numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün numarası boş olamaz.")
                .GreaterThan(0).WithMessage("Ürün numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Miktar bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("Miktar bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}

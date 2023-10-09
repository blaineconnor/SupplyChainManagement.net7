using FluentValidation;
using SCM.Application.Models.RequestModels.RequestDetails;

namespace SCM.Application.Validators.RequestDetails
{
    public class CreateRequestDetailValidator : AbstractValidator<CreateRequestDetailVM>
    {
        public CreateRequestDetailValidator()
        {
            RuleFor(request => request.RequestId).NotEmpty().WithMessage("Talep kimliği boş olamaz.");
            RuleFor(request => request.ProductId).NotEmpty().WithMessage("Ürün kimliği boş olamaz.");
            RuleFor(request => request.Quantity).GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");
            RuleFor(request => request.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(request => request.RequestDescription).NotEmpty().WithMessage("Talep açıklaması boş olamaz.");
        }
    }
}

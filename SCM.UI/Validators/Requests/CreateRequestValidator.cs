using FluentValidation;
using SCM.UI.Models.RequestModels.Requests;

namespace SCM.UI.Validators.Requests
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestVM>
    {
        public CreateRequestValidator()
        {
            RuleFor(request => request.HowMany)
                .GreaterThan(0).WithMessage("Talep miktarı 0'dan büyük olmalıdır.");
            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("Açıklama bilgisi boş olamaz.");
        }
    }
}

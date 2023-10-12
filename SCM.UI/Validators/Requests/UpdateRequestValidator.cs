using FluentValidation;
using SCM.UI.Models.RequestModels.Requests;

namespace SCM.UI.Validators.Requests
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestVM>
    {
        public UpdateRequestValidator()
        {
            RuleFor(request => request.RequestId)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("Kullanıcı kimliği boş olamaz.");
            RuleFor(request => request.HowMany)
                .GreaterThan(0).WithMessage("Talep miktarı 0'dan büyük olmalıdır.");
        }
    }
}

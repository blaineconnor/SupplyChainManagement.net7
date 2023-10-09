using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestVM>
    {
        public UpdateRequestValidator()
        {
            RuleFor(request => request.RequestId)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("Kullanıcı kimliği boş olamaz.");
            RuleFor(request => request.RequestDate)
                .NotEmpty().WithMessage("Talep tarihi boş olamaz.");
            RuleFor(request => request.Status)
                .IsInEnum().WithMessage("Geçersiz talep durumu.");
            RuleFor(request => request.Amount)
                .GreaterThan(0).WithMessage("Talep miktarı 0'dan büyük olmalıdır.");
        }
    }
}

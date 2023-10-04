using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestVM>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("Kullanıcı numarası boş olamaz.")
               .GreaterThan(0).WithMessage("Kullanıcı numarası sıfırdan büyük bir sayı olmalıdır.");
        }
    }
}

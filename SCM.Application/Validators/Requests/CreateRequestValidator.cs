using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestVM>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.TheRequest)
                .NotEmpty().WithMessage("Talep boş olamaz.");
        }
    }
}

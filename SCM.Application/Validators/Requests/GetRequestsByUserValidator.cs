using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class GetRequestsByUserValidator : AbstractValidator<GetRequestsByUserVM>
    {
        public GetRequestsByUserValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı Adı boş olamaz.");
        }
    }
}

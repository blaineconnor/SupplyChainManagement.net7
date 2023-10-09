using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class GetRequestsByUserValidator : AbstractValidator<GetRequestsByUserVM>
    {
        public GetRequestsByUserValidator()
        {
            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("Kullanıcı kimliği boş olamaz.");
        }
    }
}

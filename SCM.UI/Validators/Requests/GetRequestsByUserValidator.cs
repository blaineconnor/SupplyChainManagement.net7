using FluentValidation;
using SCM.UI.Models.RequestModels.Requests;

namespace SCM.UI.Validators.Requests
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

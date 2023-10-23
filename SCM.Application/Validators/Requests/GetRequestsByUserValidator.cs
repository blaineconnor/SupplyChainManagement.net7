using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class GetRequestsByUserValidator : AbstractValidator<GetRequestsByUserVM>
    {
        public GetRequestsByUserValidator()
        {
            RuleFor(request => request.EmployeeId)
                .NotEmpty().WithMessage("Kullanıcı kimliği boş olamaz.");
        }
    }
}

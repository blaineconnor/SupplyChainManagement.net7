using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;
using System.Security.Cryptography.X509Certificates;

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

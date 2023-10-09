using FluentValidation;
using SCM.Application.Models.RequestModels.RequestDetails;

namespace SCM.Application.Validators.RequestDetails
{
    public class GetRequestDetailsByRequestIdValidator : AbstractValidator<GetRequestDetailsByRequestIdVM>
    {
        public GetRequestDetailsByRequestIdValidator()
        {
            RuleFor(request => request.RequestId)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
        }
    }
}

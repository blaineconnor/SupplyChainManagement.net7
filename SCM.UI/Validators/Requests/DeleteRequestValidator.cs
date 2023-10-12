using FluentValidation;
using SCM.UI.Models.RequestModels.Requests;

namespace SCM.UI.Validators.Requests
{
    public class DeleteRequestValidator : AbstractValidator<DeleteRequestVM>
    {
        public DeleteRequestValidator()
        {
            RuleFor(request => request.RequestId)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
        }
    }
}

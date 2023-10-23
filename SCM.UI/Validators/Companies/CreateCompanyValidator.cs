using FluentValidation;
using SCM.UI.Models.RequestModels.Companies;

namespace SCM.UI.Validators.Companies
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyVM>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Şirket adı 100 karakterden fazla olamaz.");
        }
    }
}

using FluentValidation;
using SCM.Application.Models.RequestModels.Companies;

namespace SCM.Application.Validators.Companies
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyVM>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Şirket adı 100 karakterden fazla olamaz.");
        }
    }
}

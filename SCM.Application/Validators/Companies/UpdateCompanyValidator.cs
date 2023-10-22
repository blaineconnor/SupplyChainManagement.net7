using FluentValidation;
using SCM.Application.Models.RequestModels.Companies;

namespace SCM.Application.Validators.Companies
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyVM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Şirket kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Şirket kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Şirket adı 100 karakterden fazla olamaz.");
        }
    }
}

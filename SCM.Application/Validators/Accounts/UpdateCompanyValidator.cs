using FluentValidation;
using SCM.Application.Models.RequestModels.Accounts;

namespace SCM.Application.Validators.Accounts
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyVM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Company)
                .NotEmpty()
                .WithMessage("Şirket bilgisini seçmeden giriş yapamazsınız.");
        }
    }
}

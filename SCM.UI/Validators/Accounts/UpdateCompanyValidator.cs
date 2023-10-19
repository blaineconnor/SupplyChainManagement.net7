using FluentValidation;
using SCM.UI.Models.RequestModels.Accounts;

namespace SCM.UI.Validators.Accounts
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

using FluentValidation;
using SCM.UI.Models.RequestModels.Offers;

namespace SCM.UI.Validators.Offers
{
    public class UpdateOfferVMValidator : AbstractValidator<UpdateOfferVM>
    {
        public UpdateOfferVMValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir teklif ID'si belirtmelisiniz.");
            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Geçerli bir miktar belirtmelisiniz.");
        }
    }
}

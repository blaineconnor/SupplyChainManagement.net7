using FluentValidation;
using SCM.UI.Models.RequestModels.Offers;

namespace SCM.UI.Validators.Offers
{
    public class CreateOfferVMValidator : AbstractValidator<CreateOfferVM>
    {
        public CreateOfferVMValidator()
        {
            RuleFor(x => x.RequestId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir talep ID'si belirtmelisiniz.");
            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Geçerli bir miktar belirtmelisiniz.");
        }
    }
}

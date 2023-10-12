using FluentValidation;
using SCM.UI.Models.RequestModels.Offers;

namespace SCM.UI.Validators.Offers
{
    public class DeleteOfferValidator : AbstractValidator<DeleteOfferVM>
    {
        public DeleteOfferValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir teklif ID'si belirtmelisiniz.");
        }
    }
}

using FluentValidation;
using SCM.Application.Models.RequestModels.Offers;

namespace SCM.Application.Validators.Offers
{
    public class CreateOfferVMValidator : AbstractValidator<CreateOfferVM>
    {
        public CreateOfferVMValidator()
        {
            RuleFor(x => x.RequestId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir talep ID'si belirtmelisiniz.");

            RuleFor(x => x.SupplierName)
                .NotEmpty()
                .WithMessage("Tedarikçi adı gereklidir.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Geçerli bir miktar belirtmelisiniz.");

            RuleFor(x => x.OfferDate)
                .NotEmpty()
                .WithMessage("Teklif tarihi gereklidir.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Teklif tarihi geçmiş bir tarih olamaz.");
        }
    }
}

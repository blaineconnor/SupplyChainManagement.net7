using FluentValidation;
using SCM.UI.Models.RequestModels.Invoice;

namespace SCM.UI.Validators.Invoice
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceVM>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.RequestId)
              .NotEmpty().WithMessage("Talep kimliği boş olamaz.")
              .GreaterThan(0).WithMessage("Geçerli bir talep kimliği belirtmelisiniz.");
        }
    }
}

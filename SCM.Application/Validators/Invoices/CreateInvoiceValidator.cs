using FluentValidation;
using SCM.Application.Models.RequestModels.Invoice;

namespace SCM.Application.Validators.Invoices
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

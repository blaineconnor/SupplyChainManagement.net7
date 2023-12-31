﻿using FluentValidation;
using SCM.UI.Models.RequestModels.Invoices;

namespace SCM.UI.Validators.Invoices
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

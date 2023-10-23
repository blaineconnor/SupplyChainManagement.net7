﻿using FluentValidation;
using SCM.UI.Models.RequestModels.Companies;

namespace SCM.UI.Validators.Companies
{
    public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyVM>
    {
        public DeleteCompanyValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Şirket kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Şirket kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}

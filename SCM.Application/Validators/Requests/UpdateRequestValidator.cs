﻿using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestVM>
    {
        public UpdateRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("Ürün kimliği boş olamaz.");
            RuleFor(request => request.HowMany)
                .GreaterThan(0).WithMessage("Talep miktarı 0'dan büyük olmalıdır.");
        }
    }
}

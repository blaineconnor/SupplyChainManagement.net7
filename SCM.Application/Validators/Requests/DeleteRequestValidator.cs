﻿using FluentValidation;
using SCM.Application.Models.RequestModels.Requests;

namespace SCM.Application.Validators.Requests
{
    public class DeleteRequestValidator : AbstractValidator<DeleteRequestVM>
    {
        public DeleteRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Talep kimliği boş olamaz.");
        }
    }
}

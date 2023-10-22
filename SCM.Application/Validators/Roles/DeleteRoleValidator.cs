using FluentValidation;
using SCM.Application.Models.RequestModels.Roles;

namespace SCM.Application.Validators.Roles
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleVM>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Rol kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Rol kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}

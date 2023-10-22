using FluentValidation;
using SCM.Application.Models.RequestModels.Roles;

namespace SCM.Application.Validators.Roles
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleVM>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Rol adı boş olamaz.")
                .MaximumLength(50)
                .WithMessage("Rol adı 50 karakterden fazla olamaz.");
        }
    }
}

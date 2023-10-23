using FluentValidation;
using SCM.UI.Models.RequestModels.Departments;

namespace SCM.UI.Validators.Departments
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentVM>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Departman adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Departman adı 100 karakterden fazla olamaz.");
        }
    }
}

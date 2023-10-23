using FluentValidation;
using SCM.Application.Models.RequestModels.Departments;

namespace SCM.Application.Validators.Departments
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

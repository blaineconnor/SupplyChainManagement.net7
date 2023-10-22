using FluentValidation;
using SCM.Application.Models.RequestModels.Departments;

namespace SCM.Application.Validators.Departments
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentVM>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Departman kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Departman kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DepartmentName)
                .NotEmpty()
                .WithMessage("Departman adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Departman adı 100 karakterden fazla olamaz.");
        }
    }
}

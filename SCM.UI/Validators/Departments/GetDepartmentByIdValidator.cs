using FluentValidation;
using SCM.UI.Models.RequestModels.Departments;

namespace SCM.UI.Validators.Departments
{
    public class GetDepartmentByIdValidator : AbstractValidator<GetDepartmentByIdVM>
    {
        public GetDepartmentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Departman kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Departman kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}

using FluentValidation;
using SCM.Application.Models.RequestModels.Supplier;

namespace SCM.Application.Validators.Companies
{
    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierVM>
    {
        public DeleteSupplierValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}

using FluentValidation;
using SCM.UI.Models.RequestModels.Supplier;

namespace SCM.UI.Validators.Suppliers
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

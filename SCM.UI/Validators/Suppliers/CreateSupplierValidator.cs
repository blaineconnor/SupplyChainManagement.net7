using FluentValidation;
using SCM.UI.Models.RequestModels.Supplier;

namespace SCM.UI.Validators.Suppliers
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierVM>
    {
        public CreateSupplierValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Tedarikçi adı 100 karakterden fazla olamaz.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("E-posta adı boş olamaz.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Telefon numarası boş bırakılamaz.");
        }
    }
}

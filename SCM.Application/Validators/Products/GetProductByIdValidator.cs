using FluentValidation;
using SCM.Application.Models.RequestModels.Products;

namespace SCM.Application.Validators.Products
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdVM>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Ürünün kimlik bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("Ürünün kimlik bilgisi sıfırdan büyük bir sayı olmalıdır.");
        }
    }
}

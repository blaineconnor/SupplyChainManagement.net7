using FluentValidation;
using SCM.Application.Models.RequestModels.Products;

namespace SCM.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductVM>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Ürünün kimlik bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("Ürünün kimlik bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Ürüne ait kategori bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("Kategori bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Ürünün adı boş olamaz.")
                .MaximumLength(255).WithMessage("Ürün adı en fazla 255 karakter olabilir.");

            RuleFor(x => x.Detail)
                .NotNull().WithMessage("Ürünün detay bilgisi boş olamaz.");

            RuleFor(x => x.UnitInStock)
                .NotNull().WithMessage("Ürün stok adedi boş olamaz.");

            RuleFor(x => x.UnitPrice)
                .NotNull().WithMessage("Ürün fiyatı boş olamaz.");
        }
    }
}

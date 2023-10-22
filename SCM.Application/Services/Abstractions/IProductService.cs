using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.RequestModels.Products;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface IProductService
    {
        #region Select

        Task<Result<List<ProductDTO>>> GetAllProducts();
        Task<Result<ProductDTO>> GetProductById(GetProductByIdVM getProductByIdVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<BigInteger>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<BigInteger>> UpdateProduct(UpdateProductVM updateProductVM);
        Task<Result<BigInteger>> DeleteProduct(DeleteProductVM deleteProductVM);

        #endregion
    }
}

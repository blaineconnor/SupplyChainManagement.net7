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

        Task<Result<Int64>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<Int64>> UpdateProduct(UpdateProductVM updateProductVM);
        Task<Result<Int64>> DeleteProduct(DeleteProductVM deleteProductVM);

        #endregion
    }
}

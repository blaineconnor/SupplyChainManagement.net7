using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.RequestModels.Products;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface IProductService
    {
        #region Select

        Task<Result<List<ProductDTO>>> GetAllProducts();
        Task<Result<ProductDTO>> GetProductById(GetProductByIdVM getProductByIdVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<int>> UpdateProduct(UpdateProductVM updateProductVM);
        Task<Result<int>> DeleteProduct(DeleteProductVM deleteProductVM);

        #endregion
    }
}

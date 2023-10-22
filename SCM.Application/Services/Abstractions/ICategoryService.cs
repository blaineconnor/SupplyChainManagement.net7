using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface ICategoryService
    {
        #region Select
        Task<Result<List<CategoryDTO>>> GetAllCategories();
        Task<Result<CategoryDTO>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<BigInteger>> CreateCategory(CreateCategoryVM createCategoryVM);
        Task<Result<BigInteger>> UpdateCategory(UpdateCategoryVM updateCategoryVM);
        Task<Result<BigInteger>> DeleteCategory(DeleteCategoryVM deleteCategoryVM);
        #endregion
    }
}

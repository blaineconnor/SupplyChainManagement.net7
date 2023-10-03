using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Wrapper;

namespace SCM.Application.Services.Abstractions
{
    public interface ICategoryService
    {
        #region Select
        Task<Result<List<CategoryDTO>>> GetAllCategories();
        Task<Result<CategoryDTO>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM);
        Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM);
        Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM);
        #endregion
    }
}

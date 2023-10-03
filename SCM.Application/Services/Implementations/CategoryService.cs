using AutoMapper;
using AutoMapper.QueryableExtensions;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Categories;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Data.Entity;

namespace SCM.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _db;

        public CategoryService(IMapper mapper, IUnitWork db)
        {
            _mapper = mapper;
            _db = db;
        }


        #region Select
        [PerformanceBehavior]
        public async Task<Result<List<CategoryDTO>>> GetAllCategories()
        {
            var result = new Result<List<CategoryDTO>>();

            var categoryEntites = await _db.GetRepository<Categories>().GetAllAsync();
            var categoryDtos = await categoryEntites.ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = categoryDtos;
            _db.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCategoryByIdValidator))]
        public async Task<Result<CategoryDTO>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
        {
            var result = new Result<CategoryDTO>();

            var categoryExists = await _db.GetRepository<Categories>().AnyAsync(x => x.Id == getCategoryByIdVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
            }

            var categoryEntity = await _db.GetRepository<Categories>().GetById(getCategoryByIdVM.Id);

            var categoryDto = _mapper.Map<Categories, CategoryDTO>(categoryEntity);

            result.Data = categoryDto;
            _db.Dispose();
            return result;
        }
        #endregion

        #region Insert, Update, Delete

        [ValidationBehavior(typeof(CreateCategoryValidator))]
        public async Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
           var result = new Result<int>();

            var categoryExistsSameName = await _db.GetRepository<Categories>().AnyAsync(x => x.Name == createCategoryVM.CategoryName);
            if (categoryExistsSameName)
            {
                throw new AlreadyExistsException($"{createCategoryVM.CategoryName} isminde bir kategori zaten mevcut.");
            }

            var categoryEntity = _mapper.Map<CreateCategoryVM, Categories>(createCategoryVM);

            _db.GetRepository<Categories>().Add(categoryEntity);
            await _db.CommitAsync();

            result.Data = categoryEntity.Id;
            _db.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(DeleteCategoryValidator))]
        public async Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var result = new Result<int>();

            var categoryExists = await _db.GetRepository<Categories>().AnyAsync(x => x.Id == deleteCategoryVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
            }

            _db.GetRepository<Categories>().Delete(deleteCategoryVM.Id);
            await _db.CommitAsync();

            result.Data = deleteCategoryVM.Id;
            _db.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateCategoryValidator))]
        public async Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            var result = new Result<int>();

            var existsCategory = await _db.GetRepository<Categories>().GetById(updateCategoryVM.Id);
            if (existsCategory is null)
            {
                throw new Exception($"{updateCategoryVM} numaralı kategori bulunamadı.");
            }

            var updatedCategory = _mapper.Map(updateCategoryVM, existsCategory);

            _db.GetRepository<Categories>().Update(updatedCategory);
            await _db.CommitAsync();

            result.Data = updatedCategory.Id;
            _db.Dispose();
            return result;
        }

        #endregion
    }
}

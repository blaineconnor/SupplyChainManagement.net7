using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Companies;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Numerics;

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

            var categoryEntites = await _db.GetRepository<Category>().GetAllAsync();
            var categoryDtos = await categoryEntites.ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = categoryDtos;
            _db.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCompanyByIdValidator))]
        public async Task<Result<CategoryDTO>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM)
        {
            var result = new Result<CategoryDTO>();

            var categoryExists = await _db.GetRepository<Category>().AnyAsync(x => x.Id == getCategoryByIdVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{getCategoryByIdVM.Id} numaralı kategori bulunamadı.");
            }

            var categoryEntity = await _db.GetRepository<Category>().GetById(getCategoryByIdVM.Id);

            var categoryDto = _mapper.Map<Category, CategoryDTO>(categoryEntity);

            result.Data = categoryDto;
            _db.Dispose();
            return result;
        }
        #endregion

        #region Insert, Update, Delete

        [ValidationBehavior(typeof(CreateCompanyValidator))]
        public async Task<Result<BigInteger>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var result = new Result<BigInteger>();

            var categoryExistsSameName = await _db.GetRepository<Category>().AnyAsync(x => x.Name == createCategoryVM.CategoryName);
            if (categoryExistsSameName)
            {
                throw new AlreadyExistsException($"{createCategoryVM.CategoryName} isminde bir kategori zaten mevcut.");
            }

            var categoryEntity = _mapper.Map<CreateCategoryVM, Category>(createCategoryVM);

            _db.GetRepository<Category>().Add(categoryEntity);
            await _db.CommitAsync();

            result.Data = categoryEntity.Id;
            _db.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(DeleteCompanyValidator))]
        public async Task<Result<BigInteger>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var result = new Result<BigInteger>();

            var categoryExists = await _db.GetRepository<Category>().AnyAsync(x => x.Id == deleteCategoryVM.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryVM.Id} numaralı kategori bulunamadı.");
            }

            _db.GetRepository<Category>().Delete(deleteCategoryVM.Id);
            await _db.CommitAsync();

            result.Data = deleteCategoryVM.Id;
            _db.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateCompanyValidator))]
        public async Task<Result<BigInteger>> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            var result = new Result<BigInteger>();

            var existsCategory = await _db.GetRepository<Category>().GetById(updateCategoryVM.Id);
            if (existsCategory is null)
            {
                throw new Exception($"{updateCategoryVM} numaralı kategori bulunamadı.");
            }

            var updatedCategory = _mapper.Map(updateCategoryVM, existsCategory);

            _db.GetRepository<Category>().Update(updatedCategory);
            await _db.CommitAsync();

            result.Data = updatedCategory.Id;
            _db.Dispose();
            return result;
        }

        #endregion
    }
}

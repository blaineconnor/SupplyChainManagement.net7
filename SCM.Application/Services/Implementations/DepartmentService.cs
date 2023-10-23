using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Departments;
using SCM.Application.Models.RequestModels.Departments;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Companies;
using SCM.Application.Validators.Departments;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Numerics;

namespace SCM.Application.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        #region Create, Update, Delete

        [ValidationBehavior(typeof(CreateDepartmentValidator))]

        public async Task<Result<Int64>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var result = new Result<Int64>();

            var departmentExistsSameName = await _uWork.GetRepository<Department>().AnyAsync(x => x.Name == createDepartmentVM.DepartmentName);
            if (departmentExistsSameName)
            {
                throw new AlreadyExistsException($"{createDepartmentVM.DepartmentName} isminde bir departman zaten mevcut.");
            }

            var departmentEntity = _mapper.Map<CreateDepartmentVM, Department>(createDepartmentVM);

            _uWork.GetRepository<Department>().Add(departmentEntity);
            await _uWork.CommitAsync();

            result.Data = departmentEntity.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteDepartmentValidator))]

        public async Task<Result<Int64>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM)
        {
            var result = new Result<Int64>();

            var companyExists = await _uWork.GetRepository<Department>().AnyAsync(x => x.Id == deleteDepartmentVM.Id);
            if (!companyExists)
            {
                throw new NotFoundException($"{deleteDepartmentVM.Id} numaralı departman bulunamadı.");
            }

            _uWork.GetRepository<Department>().Delete(deleteDepartmentVM.Id);
            await _uWork.CommitAsync();

            result.Data = deleteDepartmentVM.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateDepartmentValidator))]

        public async Task<Result<Int64>> UpdateDepartment(UpdateDepartmentVM updateDepartmentVM)
        {
            var result = new Result<Int64>();

            var existsDepartment = await _uWork.GetRepository<Department>().GetById(updateDepartmentVM.Id);
            if (existsDepartment is null)
            {
                throw new Exception($"{updateDepartmentVM} numaralı departman bulunamadı.");
            }

            var updatedDepartment = _mapper.Map(updateDepartmentVM, existsDepartment);

            _uWork.GetRepository<Department>().Update(updatedDepartment);
            await _uWork.CommitAsync();

            result.Data = updatedDepartment.Id;
            _uWork.Dispose();
            return result;
        }

        #endregion

        #region Select

        public async Task<Result<List<DepartmentDTO>>> GetAllDepartments()
        {
            var result = new Result<List<DepartmentDTO>>();

            var departmentEntites = await _uWork.GetRepository<Department>().GetAllAsync();
            var departmentDtos = await departmentEntites.ProjectTo<DepartmentDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = departmentDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetDepartmentByIdValidator))]

        public async Task<Result<DepartmentDTO>> GetDepartmentById(GetDepartmentByIdVM getDepartmentByIdVM)
        {
            var result = new Result<DepartmentDTO>();

            var departmentExists = await _uWork.GetRepository<Department>().AnyAsync(x => x.Id == getDepartmentByIdVM.Id);
            if (!departmentExists)
            {
                throw new NotFoundException($"{getDepartmentByIdVM.Id} numaralı departman bulunamadı.");
            }

            var departmentEntity = await _uWork.GetRepository<Department>().GetById(getDepartmentByIdVM.Id);

            var departmentDto = _mapper.Map<Department, DepartmentDTO>(departmentEntity);

            result.Data = departmentDto;
            _uWork.Dispose();
            return result;
        }

        #endregion
    }
}

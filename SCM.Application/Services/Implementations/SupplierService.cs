using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Suppliers;
using SCM.Application.Models.RequestModels.Supplier;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Companies;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Numerics;

namespace SCM.Application.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        #region Create

        [ValidationBehavior(typeof(CreateSupplierValidator))]

        public async Task<Result<Int64>> CreateSupplier(CreateSupplierVM createSupplierVM)
        {
            var result = new Result<Int64>();

            var supplierExistsSameName = await _uWork.GetRepository<Supplier>().AnyAsync(x => x.Name == createSupplierVM.Name);
            if (supplierExistsSameName)
            {
                throw new AlreadyExistsException($"{createSupplierVM.Name} isminde bir tedarikçi zaten mevcut.");
            }

            var supplierEntity = _mapper.Map<CreateSupplierVM, Supplier>(createSupplierVM);

            _uWork.GetRepository<Supplier>().Add(supplierEntity);
            await _uWork.CommitAsync();

            result.Data = supplierEntity.Id;
            _uWork.Dispose();
            return result;
        }
        #endregion

        #region Delete

        [ValidationBehavior(typeof(DeleteSupplierValidator))]

        public async Task<Result<Int64>> DeleteSupplier(DeleteSupplierVM deleteSupplierVM)
        {
            var result = new Result<Int64>();

            var supplierExists = await _uWork.GetRepository<Supplier>().AnyAsync(x => x.Id == deleteSupplierVM.Id);
            if (!supplierExists)
            {
                throw new NotFoundException($"{deleteSupplierVM.Id} numaralı tedarikçi bulunamadı.");
            }

            _uWork.GetRepository<Supplier>().Delete(deleteSupplierVM.Id);
            await _uWork.CommitAsync();

            result.Data = deleteSupplierVM.Id;
            _uWork.Dispose();
            return result;
        }
        #endregion

        #region Get
        public async Task<Result<List<SupplierDTO>>> GetAllSuppliers()
        {
            var result = new Result<List<SupplierDTO>>();

            var supplierEntites = await _uWork.GetRepository<Supplier>().GetAllAsync();
            var supplierDtos = await supplierEntites.ProjectTo<SupplierDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = supplierDtos;
            _uWork.Dispose();
            return result;
        }
        #endregion
    }
}

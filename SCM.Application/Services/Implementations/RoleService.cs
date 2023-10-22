using AutoMapper;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.RequestModels.Roles;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Roles;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Numerics;

namespace SCM.Application.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public RoleService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        #region Create

        [ValidationBehavior(typeof(CreateRoleValidator))]

        public async Task<Result<BigInteger>> CreateRole(CreateRoleVM createRoleVM)
        {
            var result = new Result<BigInteger>();

            var RoleExistsSameName = await _uWork.GetRepository<Role>().AnyAsync(x => x.RoleName == createRoleVM.RoleName);
            if (RoleExistsSameName)
            {
                throw new AlreadyExistsException($"{createRoleVM.RoleName} isminde bir rol zaten mevcut.");
            }

            var roleEntity = _mapper.Map<CreateRoleVM, Role>(createRoleVM);

            _uWork.GetRepository<Role>().Add(roleEntity);
            await _uWork.CommitAsync();

            result.Data = roleEntity.Id;
            _uWork.Dispose();
            return result;
        }
        #endregion

        #region Delete
        [ValidationBehavior(typeof(DeleteRoleValidator))]

        public async Task<Result<BigInteger>> DeleteRole(DeleteRoleVM deleteRoleVM)
        {
            var result = new Result<BigInteger>();

            var roleExists = await _uWork.GetRepository<Category>().AnyAsync(x => x.Id == deleteRoleVM.Id);
            if (!roleExists)
            {
                throw new NotFoundException($"{deleteRoleVM.Id} numaralı rol bulunamadı.");
            }

            _uWork.GetRepository<Role>().Delete(deleteRoleVM.Id);
            await _uWork.CommitAsync();

            result.Data = deleteRoleVM.Id;
            _uWork.Dispose();
            return result;
        }
        #endregion
    }
}

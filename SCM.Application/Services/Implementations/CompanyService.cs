using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.RequestModels.Companies;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Companies;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Numerics;

namespace SCM.Application.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        #region Create, Update, Delete

        [ValidationBehavior(typeof(CreateCompanyValidator))]
        public async Task<Result<BigInteger>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var result = new Result<BigInteger>();

            var companyExistsSameName = await _uWork.GetRepository<Company>().AnyAsync(x => x.Name == createCompanyVM.CompanyName);
            if (companyExistsSameName)
            {
                throw new AlreadyExistsException($"{createCompanyVM.CompanyName} isminde bir şirket zaten mevcut.");
            }

            var companyEntity = _mapper.Map<CreateCompanyVM, Company>(createCompanyVM);

            _uWork.GetRepository<Company>().Add(companyEntity);
            await _uWork.CommitAsync();

            result.Data = companyEntity.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteCompanyValidator))]

        public async Task<Result<BigInteger>> DeleteCompany(DeleteCompanyVM deleteCompanyVM)
        {
            var result = new Result<BigInteger>();

            var companyExists = await _uWork.GetRepository<Company>().AnyAsync(x => x.Id == deleteCompanyVM.Id);
            if (!companyExists)
            {
                throw new NotFoundException($"{deleteCompanyVM.Id} numaralı şirket bulunamadı.");
            }

            _uWork.GetRepository<Company>().Delete(deleteCompanyVM.Id);
            await _uWork.CommitAsync();

            result.Data = deleteCompanyVM.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateCompanyValidator))]

        public async Task<Result<BigInteger>> UpdateCompany(UpdateCompanyVM updateCompanyVM)
        {
            var result = new Result<BigInteger>();

            var existsCompany = await _uWork.GetRepository<Company>().GetById(updateCompanyVM.Id);
            if (existsCompany is null)
            {
                throw new Exception($"{updateCompanyVM} numaralı şirket bulunamadı.");
            }

            var updatedCompany = _mapper.Map(updateCompanyVM, existsCompany);

            _uWork.GetRepository<Company>().Update(updatedCompany);
            await _uWork.CommitAsync();

            result.Data = updatedCompany.Id;
            _uWork.Dispose();
            return result;
        }

        #endregion

        #region Select

        public async Task<Result<List<CompanyDTO>>> GetAllCompanies()
        {
            var result = new Result<List<CompanyDTO>>();

            var companyEntites = await _uWork.GetRepository<Company>().GetAllAsync();
            var companyDtos = await companyEntites.ProjectTo<CompanyDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = companyDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCompanyByIdValidator))]
        public async Task<Result<CompanyDTO>> GetCompanyById(GetCompanyByIdVM getCompanyByIdVM)
        {
            var result = new Result<CompanyDTO>();

            var companyyExists = await _uWork.GetRepository<Company>().AnyAsync(x => x.Id == getCompanyByIdVM.Id);
            if (!companyyExists)
            {
                throw new NotFoundException($"{getCompanyByIdVM.Id} numaralı şirket bulunamadı.");
            }

            var companyEntity = await _uWork.GetRepository<Company>().GetById(getCompanyByIdVM.Id);

            var companyDto = _mapper.Map<Company, CompanyDTO>(companyEntity);

            result.Data = companyDto;
            _uWork.Dispose();
            return result;
        }

        #endregion

    }
}

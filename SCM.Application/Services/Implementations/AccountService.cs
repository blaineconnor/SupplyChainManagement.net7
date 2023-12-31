﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Accounts;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using SCM.Persistence.Context;
using SCM.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SCM.Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        private readonly IConfiguration _configuration;
        private readonly SCM_Context _dbContext;

        public AccountService(IMapper mapper, IUnitWork uWork, IConfiguration configuration, SCM_Context dbContext)
        {
            _mapper = mapper;
            _uWork = uWork;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        #region Company Login

        [ValidationBehavior(typeof(LoginValidator))]
        public async Task<Result<TokenDTO>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDTO>();
            var hashedPassword = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsAccount = await _uWork.GetRepository<Account>().GetSingleByFilterAsync(x => x.UserName == loginVM.UserName && x.Password == hashedPassword, "Employee");

            if (existsAccount is null)
            {
                throw new NotFoundException($"{loginVM.UserName} kullanıcı adına sahip kullanıcı bulunamadı ya da parola hatalıdır.");
            }

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);

            var tokenString = GenerateJwtToken(existsAccount, expireDate);
            result.Data = new TokenDTO
            {
                Token = tokenString,
                ExpireDate = expireDate,
                Auth = existsAccount.Authorization
            };

           
            return result;
        }
        #endregion

        #region Supplier Login

        [ValidationBehavior(typeof(LoginValidator))]
        public async Task<Result<TokenDTO>> SupplierLogin(LoginVM loginVM)
        {
            var result = new Result<TokenDTO>();
            var hashedPassword = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsAccount = await _uWork.GetRepository<Account>().GetSingleByFilterAsync(x => x.UserName == loginVM.UserName && x.Password == hashedPassword, "Supplier");

            if (existsAccount is null)
            {
                throw new NotFoundException($"{loginVM.UserName} kullanıcı adına sahip tedarikçi bulunamadı ya da parola hatalıdır.");
            }

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);

            var tokenString = GenerateSuppJwtToken(existsAccount, expireDate);
            result.Data = new TokenDTO
            {
                Token = tokenString,
                ExpireDate = expireDate,
                Auth = existsAccount.Authorization
            };

            return result;
        }
        #endregion

        #region Register Employee
        [ValidationBehavior(typeof(RegisterValidator))]
        public async Task<Result<bool>> Register(RegisterVM registerVM)
        {
            var result = new Result<bool>();

            var usernameExists = await _uWork.GetRepository<Account>().AnyAsync(x => x.UserName.Trim().ToUpper() == registerVM.UserName.Trim().ToUpper());
            if (usernameExists)
            {
                throw new AlreadyExistsException($"{registerVM.UserName} kullanıcı adı daha önce seçilmiştir. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            var emailExists = await _uWork.GetRepository<Employee>().AnyAsync(x => x.Email.Trim().ToUpper() == registerVM.Email.Trim().ToUpper());
            if (emailExists)
            {
                throw new AlreadyExistsException($"{registerVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir e-posta adresi ile tekrar deneyiniz.");
            }

            var userEntity = _mapper.Map<Employee>(registerVM);
            var accountEntity = _mapper.Map<Account>(registerVM);
            accountEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);

            accountEntity.Employee = userEntity;
            
            _uWork.GetRepository<Employee>().Add(userEntity);
            _uWork.GetRepository<Account>().Add(accountEntity);

            result.Data = await _uWork.CommitAsync();

            return result;
        }
        #endregion

        #region Register Supplier
        [ValidationBehavior(typeof(RegisterValidator))]
        public async Task<Result<bool>> RegisterSupplier(RegSuppVM regSuppVM)
        {
            var result = new Result<bool>();

            var usernameExists = await _uWork.GetRepository<Account>().AnyAsync(x => x.UserName.Trim().ToUpper() == regSuppVM.UserName.Trim().ToUpper());
            if (usernameExists)
            {
                throw new AlreadyExistsException($"{regSuppVM.UserName} kullanıcı adı daha önce seçilmiştir. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            var emailExists = await _uWork.GetRepository<Supplier>().AnyAsync(x => x.Email.Trim().ToUpper() == regSuppVM.Email.Trim().ToUpper());
            if (emailExists)
            {
                throw new AlreadyExistsException($"{regSuppVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir e-posta adresi ile tekrar deneyiniz.");
            }

            var suppEntity = _mapper.Map<Supplier>(regSuppVM);
            var accountEntity = _mapper.Map<Account>(regSuppVM);
            accountEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);

            accountEntity.Supplier = suppEntity;

            _uWork.GetRepository<Supplier>().Add(suppEntity);
            _uWork.GetRepository<Account>().Add(accountEntity);

            result.Data = await _uWork.CommitAsync();

            return result;
        }
        #endregion

        #region Get

        public async Task<Result<Account>> GetByIdAsync(Int64 id)
        {
            var result = new Result<Account>();
            var account = await _dbContext.Accounts.FindAsync(id);

            if (account != null)
            {
                result.Data = account;
            }
            else
            {
                result.Success = false;
                result.Errors.Add("Hesap bulunamadı.");
            }

            return result;
        }

        #endregion

        #region Update
        public async Task<Result<bool>> UpdateUserAuths(string username, Authorization newAuth)
        {
            var result = new Result<bool>();

            var account = _dbContext.Accounts.FirstOrDefault(a => a.UserName == username);
            if (account != null)
            {
                account.Authorization = newAuth;
                await _dbContext.SaveChangesAsync();
                result.Data = true;
            }
            else
            {
                result.Success = false;
                result.Errors.Add("Kullanıcı adına göre hesap bulunamadı.");
            }
            return result;
        }

        #endregion

        #region JWT Token for Employee
        private string GenerateJwtToken(Account account, DateTime expireDate)
        {
            var secretKey = _configuration["Jwt:SigningKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audiance = _configuration["Jwt:Audiance"];

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Role,account.Authorization.ToString()),
                new Claim(ClaimTypes.Name,account.UserName),
                new Claim(ClaimTypes.Email,account.Employee.Email), 
                new Claim(ClaimTypes.Sid,account.UserId.ToString()),

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF32.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate, // Token süresi (örn: 20 dakika)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion

        #region JWT Token for Supplier
        private string GenerateSuppJwtToken(Account account, DateTime expireDate)
        {
            var secretKey = _configuration["Jwt:SigningKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audiance = _configuration["Jwt:Audiance"];

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Role,account.Authorization.ToString()),
                new Claim(ClaimTypes.Name,account.UserName),
                new Claim(ClaimTypes.Email,account.Supplier.Email),
                new Claim(ClaimTypes.Sid,account.SupplierId.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF32.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate, // Token süresi (örn: 20 dakika)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion


    }
}

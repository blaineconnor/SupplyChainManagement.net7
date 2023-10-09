using AutoMapper;
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

        #region Login

        [ValidationBehavior(typeof(LoginValidator))]
        public async Task<Result<TokenDTO>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDTO>();
            var hashedPassword = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsAccount = await _uWork.GetRepository<Account>().GetSingleByFilterAsync(x => x.UserName == loginVM.UserName && x.Password == hashedPassword, "User");
            if (existsAccount is null)
            {
                throw new NotFoundException($"{loginVM.UserName} kullanıcı adına sahip kullanıcı bulunamadı ye da parola hatalıdır.");
            }


            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);

            var tokenString = GenerateJwtToken(existsAccount, expireDate);

            result.Data = new TokenDTO
            {
                Token = tokenString,
                ExpireDate = expireDate,
                Roles = existsAccount.Roles
            };

            return result;
        }
        #endregion

        #region Register
        [ValidationBehavior(typeof(RegisterValidator))]
        public async Task<Result<bool>> Register(RegisterVM registerVM)
        {
            var result = new Result<bool>();

            var usernameExists = await _uWork.GetRepository<Account>().AnyAsync(x => x.UserName.Trim().ToUpper() == registerVM.UserName.Trim().ToUpper());
            if (usernameExists)
            {
                throw new AlreadyExistsException($"{registerVM.UserName} kullanıcı adı daha önce seçilmiştir. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            var emailExists = await _uWork.GetRepository<User>().AnyAsync(x => x.Email.Trim().ToUpper() == registerVM.Email.Trim().ToUpper());
            if (emailExists)
            {
                throw new AlreadyExistsException($"{registerVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            var userEntity = _mapper.Map<User>(registerVM);
            var accountEntity = _mapper.Map<Account>(registerVM);
            accountEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);

            accountEntity.User = userEntity;

            _uWork.GetRepository<User>().Add(userEntity);
            _uWork.GetRepository<Account>().Add(accountEntity);
            result.Data = await _uWork.CommitAsync();

            return result;
        }
        #endregion

        #region Get

        public async Task<Result<Account>> GetByIdAsync(int id)
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

        [ValidationBehavior(typeof(UpdateUserValidator))]
        public async Task<Result<bool>> UpdateUserRolesByUsernameAsync(string username, Role newRoles)
        {
            var result = new Result<bool>();

            // Kullanıcı adına göre hesabı bul
            var account = _dbContext.Accounts.FirstOrDefault(a => a.UserName == username);

            if (account != null)
            {
                // Rollerini güncelle
                account.Roles = newRoles;

                // Değişiklikleri kaydet
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

        #region JWT Token
        private string GenerateJwtToken(Account account, DateTime expireDate)
        {
            var secretKey = _configuration["Jwt:SigningKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audiance = _configuration["Jwt:Audiance"];

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Role,account.Roles.ToString()),
                new Claim(ClaimTypes.Name,account.UserName),
                new Claim(ClaimTypes.Email,account.User.Email), 
                new Claim(ClaimTypes.Sid,account.UserId.ToString())
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

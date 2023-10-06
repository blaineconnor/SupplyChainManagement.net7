using AutoMapper;
using Microsoft.AspNetCore.Http;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using System.Security.Claims;

namespace SCM.Application.Services.Implementations
{
    public class ApproveService : IApproveService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveService(IUnitWork uWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _uWork = uWork;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Approve
        public async Task<Result<bool>> ApproveRequest(ApproveVM approveVM)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userRoles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var result = new Result<bool>();

            if (userRoles.Contains("Admin"))
            {
                if (approveVM.Amount <= 500000)
                {
                    var processResult = await ProcessRequest(approveVM, true);
                    if (processResult.Success)
                    {
                        result.Data = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.Errors.AddRange(processResult.Errors);
                    }
                }
                else
                {
                    result.Success = false;
                    result.Errors.Add("Admin yetkisi sadece 0-500000 aralığındaki talepleri onaylayabilir.");
                }
            }
            else if (userRoles.Contains("SuperAdmin"))
            {
                var processResult = await ProcessRequest(approveVM, true);
                if (processResult.Success)
                {
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.Errors.AddRange(processResult.Errors);
                }
            }
            else
            {
                result.Success = false;
                result.Errors.Add("Yetkiniz bulunmuyor.");
            }

            return result;
        }

        #endregion

        #region Reject

        public async Task<Result<bool>> RejectRequest(ApproveVM approveVM)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userRoles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var result = new Result<bool>();

            if (userRoles.Contains("Admin"))
            {
                if (approveVM.Amount <= 500000)
                {
                    var processResult = await ProcessRequest(approveVM, false);
                    if (processResult.Success)
                    {
                        result.Data = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.Errors.AddRange(processResult.Errors);
                    }
                }
                else
                {
                    result.Success = false;
                    result.Errors.Add("Admin yetkisi sadece 0-500000 aralığındaki talepleri reddedebilir.");
                }
            }
            else if (userRoles.Contains("SuperAdmin"))
            {
                var processResult = await ProcessRequest(approveVM, false);
                if (processResult.Success)
                {
                    result.Data = true;
                }
                else
                {
                    result.Success = false;
                    result.Errors.AddRange(processResult.Errors);
                }
            }
            else
            {
                result.Success = false;
                result.Errors.Add("Yetkiniz bulunmuyor.");
            }

            return result;
        }

        #endregion

        #region Process

        public async Task<Result<bool>> ProcessRequest(ApproveVM approveVM, bool isApproved)
        {
            // Veritabanından talebi al
            var request = await _uWork.GetRepository<Requests>().GetById(approveVM.RequestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            // Talebi onayla veya reddet
            request.IsApproved = isApproved;

            // Talebi güncelle
            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = isApproved };
        }

        #endregion
    }
}

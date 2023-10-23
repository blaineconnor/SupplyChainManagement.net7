using AutoMapper;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using SCM.Utils;

namespace SCM.Application.Services.Implementations
{
    public class ApproveService : IApproveService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        public ApproveService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        #region Manager

        public async Task<Result<bool>> ManagerApprove(ManagerApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Request>().GetById(requestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            if (request.Status != RequestStatus.Pending)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Sadece tamamlanmamış talepleri onaylayabilirsiniz." }
                };
            }

            request.Status = RequestStatus.ManagerApproved;
            request.AddedTime = DateTime.UtcNow;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            var ok = await _uWork.SendMessage($"{approveEntity.Id}  numaralı talebiniz birim amiriniz tarafından onaylandı.");
            if (ok == true)
            {
                MailUtil.SendMail(request.Employee.Email, "Talep işlemleri.", "Talebiniz aşaması güncellendi.");

            }
            return new Result<bool> { Success = true, Data = true };
        }

        #endregion

        #region Purchasing
        public async Task<Result<bool>> PurchasingApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Request>().GetById(requestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            if (request.Status != RequestStatus.OfferReceived && request.Amount <= 50000)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Sadece tekliflendirilmiş ve ₺50000 altındaki talepleri onaylayabilirsiniz." }
                };
            }
            request.Status = RequestStatus.PurchasingApproved;
            request.AddedTime = DateTime.Now;
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            var ok = await _uWork.SendMessage($"{approveEntity.Id}  numaralı talebiniz satın alma birimi tarafından onaylandı.");
            if (ok == true)
            {
                MailUtil.SendMail(request.Employee.Email, "Talep işlemleri.", "Talebiniz aşaması güncellendi.");

            }

            return new Result<bool>
            {
                Success = true,
                Message = "Talep başarıyla onaylandı."
            };
        }
        #endregion

        #region Admin
        public async Task<Result<bool>> AdminApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Request>().GetById(requestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            if (request.Status != RequestStatus.OfferReceived && request.Amount <= 500000)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Sadece tekliflendirilmiş ve ₺500.000 altındaki talepleri onaylayabilirsiniz." }
                };
            }
            request.Status = RequestStatus.AdminApproved;
            request.AddedTime    = DateTime.Now;
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            var ok = await _uWork.SendMessage($"{approveEntity.Id}  numaralı talebiniz yönetim tarafından onaylandı.");
            if (ok == true)
            {
                MailUtil.SendMail(request.Employee.Email, "Talep işlemleri.", "Talebiniz aşaması güncellendi.");

            }

            return new Result<bool>
            {
                Success = true,
                Message = "Talep başarıyla onaylandı."
            };
        }

        #endregion

        #region SuperAdmin
        public async Task<Result<bool>> SuperAdminApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Request>().GetById(requestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            if (request.Status != RequestStatus.OfferReceived)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Sadece tekliflendirilmiş talepleri onaylayabilirsiniz." }
                };
            }
            request.Status = RequestStatus.SuperAdminApproved;
            request.AddedTime = DateTime.Now;
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            var ok = await _uWork.SendMessage($"{approveEntity.Id}  numaralı talebiniz yönetim kurulu başkanı tarafından onaylandı.");
            if (ok == true)
            {
                MailUtil.SendMail(request.Employee.Email, "Talep işlemleri.", "Talebiniz aşaması güncellendi.");

            }

            return new Result<bool>
            {
                Success = true,
                Message = "Talep başarıyla onaylandı."
            };
        }

        #endregion

        #region Reject

        public async Task<Result<bool>> Reject(RejectVM rejectVM, string rejectionReason)
        {
            var requestId = rejectVM.RequestId;

            var request = await _uWork.GetRepository<Request>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.Rejected || request.Status == RequestStatus.Completed)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten reddedilmiş veya onaylandı." }
                };
            }

            request.Status = RequestStatus.Rejected;
            request.AddedTime = DateTime.Now;
            request.IsApproved = false;
            request.RejectionReason = rejectionReason;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(rejectVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            var ok = await _uWork.SendMessage($"{approveEntity.Id}  numaralı talebiniz reddedildi.");
            if (ok == true)
            {
                MailUtil.SendMail(request.Employee.Email, "Talep işlemleri.", "Talebiniz aşaması güncellendi.");

            }

            return new Result<bool> { Success = true, Data = true };
        }

        #endregion      

    }
}

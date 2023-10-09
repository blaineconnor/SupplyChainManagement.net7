using AutoMapper;
using Azure.Core;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;

namespace SCM.Application.Services.Implementations
{
    public class ApproveService : IApproveService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public ApproveService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        public async Task<Result<bool>> ManagerApprove(ApproveVM approveVM)
        {
            var request = await _uWork.GetRepository<Requests>().GetById(approveVM.RequestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            // Manager onayladı işlemi burada gerçekleştirilir
            // Örnek olarak:
            request.Status = RequestStatus.ManagerApproved;
            request.Amount = approveVM.ApprovedAmount;
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        public async Task<Result<bool>> ManagerReject(ApproveVM approveVM)
        {
            // Reddedilecek talep bilgisini alın
            var requestId = approveVM.RequestId;

            // Talebi veritabanından alın
            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            // Talep bulunamazsa veya talep zaten reddedilmişse hata döndürün
            if (request == null || request.Status == RequestStatus.ManagerApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten reddedildi veya onaylandı." }
                };
            }

            // Talebi reddedin
            request.Status = RequestStatus.Rejected;
            request.By = Role.Manager.ToString();
            request.DateTime = DateTime.Now;

            // Veritabanında güncellemeyi kaydedin
            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        public async Task<Result<bool>> PurchasingApprove(ApproveVM approveVM)
        {
            var request = await _uWork.GetRepository<Requests>().GetById(approveVM.RequestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            // Purchasing onayladı işlemi burada gerçekleştirilir
            // Örnek olarak:
            request.Status = RequestStatus.PurchasingApproved;
            request.Amount = approveVM.ApprovedAmount;
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            // Supplier'lara bildirme işlemi veya diğer adımlar burada yapılabilir

            return new Result<bool> { Success = true, Data = true };
        }

       

        public async Task<Result<bool>> AdminApprove(ApproveVM approveVM)
        {
            var request = await _uWork.GetRepository<Requests>().GetById(approveVM.RequestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            // Admin onayladı işlemi burada gerçekleştirilir
            // Örnek olarak:
            request.Status = RequestStatus.AdminApproved;
            request.Amount = approveVM.ApprovedAmount;
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            // Muhasebeye yönlendirme işlemi veya diğer adımlar burada yapılabilir

            return new Result<bool> { Success = true, Data = true };
        }

       

        public async Task<Result<bool>> SuperAdminApprove(ApproveVM approveVM)
        {
            var request = await _uWork.GetRepository<Requests>().GetById(approveVM.RequestId);

            if (request == null)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Talep bulunamadı." }
                };
            }

            // SuperAdmin onayladı işlemi burada gerçekleştirilir
            // Örnek olarak:
            request.Status = RequestStatus.SuperAdminApproved;
            request.Amount = approveVM.ApprovedAmount;
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            // Muhasebeye yönlendirme işlemi veya diğer adımlar burada yapılabilir

            return new Result<bool> { Success = true, Data = true };
        }

      

        public async Task<Result<bool>> AccountingFulfillment(ApproveVM approveVM)
        {
            // Onaylayan kişinin rolünü ve talep kimliğini alın
            var approverRole = approveVM.ApproverRole;
            var requestId = approveVM.RequestId;

            // Muhasebe tarafından onaylanmış bir talep olduğunu doğrulayın
            var request = await _uWork.GetRepository<Requests>().GetById(requestId);
            if (request == null || (request.Status != RequestStatus.AdminApproved && request.Status != RequestStatus.SuperAdminApproved))
            {
                return new Result<bool> { Success = false, Message = "Muhasebe tarafından onaylanmış bir talep bulunamadı." };
            }

            // Onay veren kişinin rolünü kontrol edin, sadece Admin veya SuperAdmin onaylayabilir
            if (approverRole != Role.Admin.ToString() && approverRole != Role.SuperAdmin.ToString())
            {
                return new Result<bool> { Success = false, Message = "Sadece Admin veya SuperAdmin talebi onaylayabilir." };
            }

            // Muhasebe işlemleri burada gerçekleştirilir
            // Örneğin, faturalandırma işlemleri burada yapılır.

            // Talebi "Completed" olarak işaretle
            request.Status = RequestStatus.Completed;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }
    }
}

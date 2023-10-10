using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;

namespace SCM.Application.Services.Implementations
{
    public class ApproveService : IApproveService
    {
        private readonly IUnitWork _uWork;
        public ApproveService(IUnitWork uWork)
        {
            _uWork = uWork;
        }

        #region Manager

        public async Task<Result<bool>> ManagerApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

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
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();            

            return new Result<bool> { Success = true, Data = true };

        }


        public async Task<Result<bool>> ManagerReject(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.ManagerApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten reddedilmiş veya onaylandı." }
                };
            }

            request.Status = RequestStatus.Rejected;
            request.By = Role.Manager.ToString();
            request.DateTime = DateTime.Now;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        #endregion

        #region Approve

        public async Task<Result<bool>> ApproveOffer(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;
            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status != RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep, reddedildi veya talep onay beklemiyor." }
                };
            }

            var userRole = approveVM.Role;
            if (request.Status == RequestStatus.OfferReceived)
            {

                if (userRole == Role.Purchasing && request.Amount <= 50000)
                {
                    request.Status = RequestStatus.PurchasingApproved;
                    request.By = userRole.ToString();
                    request.DateTime = DateTime.Now;
                }
                else if (userRole == Role.Admin && request.Amount <= 500000)
                {
                    request.Status = RequestStatus.AdminApproved;
                    request.By = userRole.ToString();
                    request.DateTime = DateTime.Now;
                }
                else if (userRole == Role.SuperAdmin)
                {
                    request.Status = RequestStatus.SuperAdminApproved;
                    request.By = userRole.ToString();
                    request.DateTime = DateTime.Now;
                }
            }
            else
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Bu talep için onay yetkiniz yok." }
                };
            }

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool>
            {
                Success = true,
                Message = "Talep başarıyla onaylandı."
            };
        }

        #endregion

        #region Reject

        public async Task<Result<bool>> RejectOffer(ApproveVM approveVM, string rejectionReason)
        {
            var requestId = approveVM.RequestId;
            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status != RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep, reddedilmiş veya talep onay beklemiyor." }
                };
            }

            var userRole = approveVM.Role; 

            request.Status = RequestStatus.OfferReceived;
            request.By = userRole.ToString();
            request.DateTime = DateTime.Now;
            request.RejectionReason = rejectionReason;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        #endregion

        #region Accounting

        public async Task<Result<bool>> AccountingFulfillment()
        {
            var approvedRequests = await _uWork.GetRepository<Requests>().GetByFilterAsync(r => r.Status == RequestStatus.AdminApproved || r.Status == RequestStatus.SuperAdminApproved || r.Status == RequestStatus.PurchasingApproved);

            foreach (var request in approvedRequests)
            {
                var offer = await _uWork.GetRepository<Offer>().GetSingleByFilterAsync(o => o.RequestId == request.Id);

                if (offer == null)
                {
                    continue;
                }

                var supplier = await _uWork.GetRepository<Supplier>().GetById(offer.SupplierId);

                if (supplier == null)
                {
                    continue;
                }

                var invoice = new Invoice
                {
                    RequestId = request.Id,
                    SupplierId = supplier.Id,
                    Amount = request.Amount,
                    InvoiceDate = DateTime.UtcNow,
                };

                _uWork.GetRepository<Invoice>().Add(invoice);

                request.Status = RequestStatus.Completed;

                _uWork.GetRepository<Requests>().Update(request);
            }

            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        #endregion       

    }
}

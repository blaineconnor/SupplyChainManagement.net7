using AutoMapper;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Services.Abstractions;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;

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
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

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
            request.DateTime = DateTime.Now;
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

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
            request.DateTime = DateTime.Now;
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

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
            request.IsApproved = true;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(approveVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

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
            request.By = Role.Manager.ToString();
            request.DateTime = DateTime.Now;
            request.IsApproved = false;
            request.RejectionReason = rejectionReason;

            _uWork.GetRepository<Request>().Update(request);
            await _uWork.CommitAsync();

            var approveEntity = _mapper.Map<Approves>(rejectVM);

            _uWork.GetRepository<Approves>().Add(approveEntity);
            await _uWork.CommitAsync();

            return new Result<bool> { Success = true, Data = true };
        }

        #endregion

        #region Accounting

        public async Task<Result<bool>> AccountingFulfillment(CreateInvoiceVM accountingVM)
        {
            var approvedRequests = await _uWork.GetRepository<Request>().GetByFilterAsync(r => r.Status == RequestStatus.AdminApproved || r.Status == RequestStatus.SuperAdminApproved || r.Status == RequestStatus.PurchasingApproved);
            var requestId = accountingVM.RequestId;

            foreach (var request in approvedRequests)
            {
                var offer = await _uWork.GetRepository<Offer>().GetById(requestId);

                if (offer == null)
                {
                    continue;
                }

                var supplier = await _uWork.GetRepository<Account>().GetById(offer.Id);

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
                await _uWork.CommitAsync();


                request.Status = RequestStatus.Completed;

                _uWork.GetRepository<Request>().Update(request);

                await _uWork.CommitAsync();
            }

            await _uWork.CommitAsync();

            return new Result<bool>
            {
                Success = true,
                Message = "Faturalandırma yapıldı."
            };
        }

        #endregion

    }
}

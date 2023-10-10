using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        private readonly OfferService _offerService;
        private readonly ApproveService _approveService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApproveService(IUnitWork uWork, IMapper mapper, OfferService offerService, ApproveService approveService, IHttpContextAccessor httpContextAccessor)
        {
            _uWork = uWork;
            _mapper = mapper;
            _offerService = offerService;
            _approveService = approveService;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Manager

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

            request.Status = RequestStatus.ManagerApproved;
            request.DateTime = DateTime.UtcNow;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            var createOfferVM = new CreateOfferVM
            {
                RequestId = approveVM.RequestId,
            };

            var createOfferResult = await _offerService.CreateOfferAsync(createOfferVM);

            if (createOfferResult.Success)
            {
                var createdOffer = createOfferResult.Data;
                var avm = new ApproveVM() { RequestId = createdOffer.RequestId };

                if (createdOffer.Amount < 50000)
                {
                    var approveResult = await _approveService.PurchasingApprove(avm);

                    if (approveResult.Success)
                    {
                        RefreshPage();
                        return new Result<bool> { Success = true, Data = true };
                    }
                    else
                    {
                        var errorMessage = "Purchasing onay işlemi başarısız oldu.";
                        return new Result<bool> { Success = false, Data = false, Message = errorMessage };
                    }
                }
                else if (createdOffer.Amount >= 50000 && createdOffer.Amount <= 500000)
                {
                    var approveResult = await _approveService.AdminApprove(avm);

                    if (approveResult.Success)
                    {
                        RefreshPage();
                        return new Result<bool> { Success = true, Data = true };
                    }
                    else
                    {
                        var errorMessage = "Admin onay işlemi başarısız oldu.";
                        return new Result<bool> { Success = false, Data = false, Message = errorMessage };
                    }
                }
                else
                {
                    var approveResult = await _approveService.SuperAdminApprove(avm);

                    if (approveResult.Success)
                    {
                        RefreshPage();
                        return new Result<bool> { Success = true, Data = true };
                    }
                    else
                    {
                        var errorMessage = "SuperAdmin onay işlemi başarısız oldu.";
                        return new Result<bool> { Success = false, Data = false, Message = errorMessage };
                    }
                }
            }
            else
            {
                var errorMessage = "Teklif oluşturulurken bir hata oluştu.";
                return new Result<bool> { Success = false, Data = false, Message = errorMessage };
            }
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

        #region Purchasing

        public async Task<Result<bool>> PurchasingApprove(ApproveVM approveVM)// int id
        {
            var requestId = approveVM.RequestId;
            var approveThreshold = 50000; // Purchasing için eşik değeri (50,000 TL)

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.ManagerApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten onaylanmış veya reddedilmiş." }
                };
            }

            if (request.Amount <= approveThreshold)
            {
                request.Status = RequestStatus.PurchasingApproved;
                request.By = Role.Purchasing.ToString();
                request.DateTime = DateTime.Now;

                _uWork.GetRepository<Requests>().Update(request);
                await _uWork.CommitAsync();

                var accountingFulfillmentResult = await AccountingFulfillment();

                return accountingFulfillmentResult;
            }
            else
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Bu talep Satın Alma tarafından onaylanamaz." }
                };
            }
        }

        public async Task<Result<bool>> PurchasingReject(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;
            var rejectThreshold = 50000; // Purchasing için eşik değeri (50,000 TL)

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten reddedildi." }
                };
            }

            if (request.Amount <= rejectThreshold)
            {
                request.Status = RequestStatus.Rejected;
                request.By = Role.Purchasing.ToString();
                request.DateTime = DateTime.Now;

                _uWork.GetRepository<Requests>().Update(request);
                await _uWork.CommitAsync();

                return new Result<bool> { Success = true, Data = true };
            }
            else
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Bu talep Satın Alma tarafından reddedilemez." }
                };
            }
        }

        #endregion

        #region Admin

        public async Task<Result<bool>> AdminApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;
            var approveThreshold = 500000; // Admin için eşik değeri (500,000 TL)

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.AdminApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten onaylanmış veya reddedilmiş." }
                };
            }

            if (request.Amount <= approveThreshold)
            {
                request.Status = RequestStatus.AdminApproved;
                request.By = Role.Admin.ToString();
                request.DateTime = DateTime.Now;

                _uWork.GetRepository<Requests>().Update(request);
                await _uWork.CommitAsync();


                var accountingFulfillmentResult = await AccountingFulfillment();

                return accountingFulfillmentResult;

            }
            else
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Bu talep Admin tarafından onaylanamaz." }
                };
            }
        }

        public async Task<Result<bool>> AdminReject(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;
            var rejectThreshold = 500000; // Admin için eşik değeri (500,000 TL)

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten reddedildi." }
                };
            }

            if (request.Amount <= rejectThreshold)
            {
                request.Status = RequestStatus.Rejected;
                request.By = Role.Admin.ToString();
                request.DateTime = DateTime.Now;

                _uWork.GetRepository<Requests>().Update(request);
                await _uWork.CommitAsync();

                return new Result<bool> { Success = true, Data = true };
            }
            else
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Bu talep Admin tarafından reddedilemez." }
                };
            }
        }

        #endregion

        #region SuperAdmin

        public async Task<Result<bool>> SuperAdminApprove(ApproveVM approveVM)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.AdminApproved || request.Status == RequestStatus.PurchasingApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten onaylanmış veya reddedilmiş." }
                };
            }

            request.Status = RequestStatus.SuperAdminApproved;
            request.By = Role.SuperAdmin.ToString();
            request.DateTime = DateTime.Now;

            _uWork.GetRepository<Requests>().Update(request);
            await _uWork.CommitAsync();

            var accountingFulfillmentResult = await AccountingFulfillment();

            return accountingFulfillmentResult;
        }

        public async Task<Result<bool>> SuperAdminReject(ApproveVM approveVM, string rejectionReason)
        {
            var requestId = approveVM.RequestId;

            var request = await _uWork.GetRepository<Requests>().GetById(requestId);

            if (request == null || request.Status == RequestStatus.AdminApproved || request.Status == RequestStatus.PurchasingApproved || request.Status == RequestStatus.Rejected)
            {
                return new Result<bool>
                {
                    Success = false,
                    Errors = new List<string> { "Geçersiz talep veya talep zaten onaylanmış veya reddedilmiş." }
                };
            }

            request.Status = RequestStatus.Rejected;
            request.By = Role.SuperAdmin.ToString();
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

        #region Additional Methods
        public void RefreshPage()
        {
            var currentHttpContext = _httpContextAccessor.HttpContext;
            if (currentHttpContext != null)
            {
                currentHttpContext.Response.Redirect(currentHttpContext.Request.Path);
            }
        }
        #endregion
    }
}

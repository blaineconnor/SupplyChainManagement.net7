using AutoMapper;
using AutoMapper.QueryableExtensions;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Invoices;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Invoices;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using SCM.Utils;
using System.Numerics;

namespace SCM.Application.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper mapper;
        private readonly IUnitWork unitWork;

        public InvoiceService(IMapper _mapper, IUnitWork _unitWork)
        {
            mapper = _mapper;
            unitWork = _unitWork;
        }

        [ValidationBehavior(typeof(CreateInvoiceValidator))]
        public async Task<Result<BigInteger>> CreateInvoice(CreateInvoiceVM createInvoiceVM)
        {
            var approvedRequests = await unitWork.GetRepository<Request>().GetByFilterAsync(r => r.Status == RequestStatus.AdminApproved || r.Status == RequestStatus.SuperAdminApproved || r.Status == RequestStatus.PurchasingApproved);

            var requestId = createInvoiceVM.RequestId;
            foreach (var request in approvedRequests)
            {
                var offer = await unitWork.GetRepository<Request>().GetById(requestId);
                if (offer == null)
                {
                    continue;
                }
                var supplier = await unitWork.GetRepository<Offer>().GetById(offer.By);

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


                var requestExists = await unitWork.GetRepository<Request>().GetSingleByFilterAsync(x => x.Id == createInvoiceVM.RequestId, "User");

                if (requestExists is null)
                {
                    throw new NotFoundException($"{createInvoiceVM.RequestId} numaralı talep bulunamdı");

                }
                else
                {
                    request.Status = RequestStatus.Completed;
                    unitWork.GetRepository<Request>().Update(requestExists);
                }

                var invoiceEntity = mapper.Map<Invoice>(createInvoiceVM);

                unitWork.GetRepository<Invoice>().Add(invoiceEntity);

                var ok = await unitWork.SendMessage($"{invoiceEntity.RequestId} numaralı talebiniz için faturalandırma işlemi yapıldı.");
                if (ok == true)
                {
                    MailUtil.SendMail(requestExists.User.Email, "Ürün Talebiniz", "Talebiniz tamamlanmıştır.");

                }

                await unitWork.CommitAsync();
            }
            return new Result<BigInteger>
            {
                Success = true,
                Message = "Faturalandırma yapıldı."
            };
        }

        public async Task<Result<List<InvoiceDTO>>> GetAllInvoice()
        {
            var result = new Result<List<InvoiceDTO>>();
            var invoicesEntity = await unitWork.GetRepository<Invoice>().GetAllAsync();
            var invoiceDTOs = invoicesEntity.ProjectTo<InvoiceDTO>(mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDTOs;
            return result;
        }
    }
}

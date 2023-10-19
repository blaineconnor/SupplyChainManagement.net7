using AutoMapper;
using AutoMapper.QueryableExtensions;
using SCM.Application.Behaviors;
using SCM.Application.Exceptions;
using SCM.Application.Models.DTOs.Invoice;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Services.Abstractions;
using SCM.Application.Validators.Invoice;
using SCM.Application.Wrapper;
using SCM.Domain.Entities;
using SCM.Domain.UnitofWork;
using SCM.Utils;

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
        public async Task<Result<int>> CreateInvoice(CreateInvoiceVM createInvoiceVM)
        {
            var approvedRequests = await unitWork.GetRepository<Requests>().GetByFilterAsync(r => r.Status == RequestStatus.AdminApproved || r.Status == RequestStatus.SuperAdminApproved || r.Status == RequestStatus.PurchasingApproved);

            var requestId = createInvoiceVM.RequestId;

            var result = new Result<int>();

            var requestExists = await unitWork.GetRepository<Requests>().GetSingleByFilterAsync(x => x.Id == createInvoiceVM.RequestId, "Account");

            if (requestExists is null)
            {
                throw new NotFoundException($"{createInvoiceVM.RequestId} numaralı talep bulunamdı");

            }
            else
            {
                requestExists.Status = RequestStatus.Completed;
                unitWork.GetRepository<Requests>().Update(requestExists);
            }




            var invoiceEntity = mapper.Map<Invoice>(createInvoiceVM);

            unitWork.GetRepository<Invoice>().Add(invoiceEntity);

            var ok = await unitWork.SendMessage($"{invoiceEntity.RequestId} numaralı talebiniz için faturalandırma işlemi yapıldı.");
            if (ok == true)
            {
                MailUtil.SendMail(requestExists.User.Email,"Ürün Talebiniz", "Talebiniz tamamlanmıştır.");

            }

            result.Data = invoiceEntity.Id;
            return result;
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

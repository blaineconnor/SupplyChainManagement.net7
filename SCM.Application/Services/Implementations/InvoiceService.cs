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
        public async Task<Result<Int64>> CreateInvoice(CreateInvoiceVM createInvoiceVM)
        {
            var requestId = createInvoiceVM.RequestId;

            // İlgili talebi al
            var request = await unitWork.GetRepository<Request>().GetSingleByFilterAsync(r => r.Id == requestId);

            if (request is null)
            {
                throw new NotFoundException($"{requestId} numaralı talep bulunamadı");
            }

            // Talebi tamamlandı olarak işaretle
            request.Status = RequestStatus.Completed;
            unitWork.GetRepository<Request>().Update(request);

            // Yeni fatura oluştur
            var invoice = new Invoice
            {
                RequestId = request.Id,
                Amount = request.Amount,  // Eğer Amount bilgisine ihtiyaç varsa
                InvoiceDate = createInvoiceVM.InvoiceDate
            };

            unitWork.GetRepository<Invoice>().Add(invoice);

            await unitWork.CommitAsync();

            return new Result<Int64>
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

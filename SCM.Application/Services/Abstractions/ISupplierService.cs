using SCM.Application.Models.DTOs.Suppliers;
using SCM.Application.Models.RequestModels.Supplier;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface ISupplierService
    {
        Task<Result<BigInteger>> CreateSupplier(CreateSupplierVM createSupplierVM);
        Task<Result<BigInteger>> DeleteSupplier(DeleteSupplierVM deleteSupplierVM);
        Task<Result<List<SupplierDTO>>> GetAllSuppliers();
    }
}

using SCM.Application.Models.DTOs.Suppliers;
using SCM.Application.Models.RequestModels.Supplier;
using SCM.Application.Wrapper;
using System.Numerics;

namespace SCM.Application.Services.Abstractions
{
    public interface ISupplierService
    {
        Task<Result<Int64>> CreateSupplier(CreateSupplierVM createSupplierVM);
        Task<Result<Int64>> DeleteSupplier(DeleteSupplierVM deleteSupplierVM);
        Task<Result<List<SupplierDTO>>> GetAllSuppliers();
    }
}

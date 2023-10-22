using AutoMapper;
using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.DTOs.Approves;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.DTOs.Companies;
using SCM.Application.Models.DTOs.Departments;
using SCM.Application.Models.DTOs.Employees;
using SCM.Application.Models.DTOs.Invoices;
using SCM.Application.Models.DTOs.Offers;
using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.DTOs.Roles;
using SCM.Application.Models.DTOs.Suppliers;
using SCM.Domain.Entities;

namespace SCM.Application.AutoMappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<Account, AccountDTO>();

            CreateMap<Department, DepartmentDTO>();

            CreateMap<Company, CompanyDTO>();

            CreateMap<Supplier, SupplierDTO>();

            CreateMap<Role, RoleDTO>();

            CreateMap<Product, ProductDTO>();

            CreateMap<Request, RequestDTO>();

            CreateMap<Approves, ApproveDTO>();

            CreateMap<Offer, OfferDTO>();

            CreateMap<Invoice, InvoiceDTO>();
        }
    }
}

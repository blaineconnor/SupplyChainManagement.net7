using AutoMapper;
using SCM.Application.Models.DTOs.Accounts;
using SCM.Application.Models.DTOs.Approves;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.DTOs.Invoice;
using SCM.Application.Models.DTOs.Offer;
using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.DTOs.Users;
using SCM.Domain.Entities;

namespace SCM.Application.AutoMappings
{
    public class DomaintoDTO : Profile
    {
        public DomaintoDTO()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Employee, UserDTO>();

            CreateMap<Account, AccountDTO>();

            CreateMap<Product, ProductDTO>();

            CreateMap<Request, RequestDTO>();

            CreateMap<Approves, ApproveDTO>();

            CreateMap<Offer, OfferDTO>();

            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
        }
    }
}

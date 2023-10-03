using AutoMapper;
using SCM.Application.Models.DTOs.Account;
using SCM.Application.Models.DTOs.Categories;
using SCM.Application.Models.DTOs.Products;
using SCM.Application.Models.DTOs.RequestDetails;
using SCM.Application.Models.DTOs.Requests;
using SCM.Domain.Entities;

namespace SCM.Application.AutoMappings
{
    public class DomaintoDTO : Profile
    {
        public DomaintoDTO()
        {
            CreateMap<Categories, CategoryDTO>();

            CreateMap<Account, AccountDTO>();

            CreateMap<Product, ProductDTO>();

            CreateMap<Requests, RequestDTO>();

            CreateMap<RequestDetail, RequestDetailDTO>();
        }
    }
}

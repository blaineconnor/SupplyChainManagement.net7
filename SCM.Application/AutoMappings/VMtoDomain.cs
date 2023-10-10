using AutoMapper;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Models.RequestModels.Products;
using SCM.Application.Models.RequestModels.RequestDetails;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Domain.Entities;

namespace SCM.Application.AutoMappings
{
    public class VMtoDomain : Profile
    {
        public VMtoDomain()
        {
            #region Category
            CreateMap<CreateCategoryVM, Categories>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));

            CreateMap<UpdateCategoryVM, Categories>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.CategoryName));
            #endregion

            #region Account
            CreateMap<RegisterVM, User>();
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Roles, y =>y.MapFrom(e => Role.User));
            CreateMap<UpdateUserVM, User>();
            #endregion

            #region Product
            CreateMap<CreateProductVM, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.Trim()));
            CreateMap<UpdateProductVM, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.Trim()));
            #endregion

            #region Request
            CreateMap<Requests, RequestDTO>().ReverseMap();
            CreateMap<CreateRequestVM, Requests>();
            CreateMap<UpdateRequestVM, Requests>();
            CreateMap<DeleteRequestVM, Requests>();
            CreateMap<GetRequestsByUserVM, Requests>();
            #endregion

            #region Offer
            CreateMap<CreateOfferVM, Offer>();
            CreateMap<UpdateOfferVM, Offer>();
            #endregion

            #region Approve
            CreateMap<ApproveVM, Approves>();
            #endregion

            #region OfferVM to ApproveVM
            CreateMap<CreateOfferVM, ApproveVM>();
            #endregion
        }
    }
}

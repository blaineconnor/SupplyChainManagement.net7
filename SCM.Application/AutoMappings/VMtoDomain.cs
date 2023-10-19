﻿using AutoMapper;
using SCM.Application.Models.DTOs.Requests;
using SCM.Application.Models.RequestModels.Accounts;
using SCM.Application.Models.RequestModels.Approves;
using SCM.Application.Models.RequestModels.Categories;
using SCM.Application.Models.RequestModels.Invoice;
using SCM.Application.Models.RequestModels.Offers;
using SCM.Application.Models.RequestModels.Products;
using SCM.Application.Models.RequestModels.Requests;
using SCM.Domain.Entities;
using static SCM.Domain.Entities.Offer;

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
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Company, y =>y.MapFrom(e => Company.Undetermined));
            CreateMap<UpdateRoleVM, User>();
            CreateMap<UpdateCompanyVM, User>();

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
            CreateMap<CreateOfferVM, Offer>()
                .ForMember(x => x.Status, y => y.MapFrom(x => OfferStatus.pending));
            CreateMap<UpdateOfferVM, Offer>();
            #endregion

            #region Approve
            CreateMap<ManagerApproveVM, Approves>();
            CreateMap<ApproveVM,Approves>();
            CreateMap<RejectVM, Approves>();

            #endregion

            #region Invoice
            CreateMap<CreateInvoiceVM, Invoice>();
            #endregion    
        }
    }
}

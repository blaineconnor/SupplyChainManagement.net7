using AutoMapper;
using SCM.UI.Models.DTOs.Accounts;
using SCM.UI.Models.DTOs.Categories;
using SCM.UI.Models.RequestModels.Accounts;
using SCM.UI.Models.RequestModels.Categories;

namespace SCM.UI.ModelMappings
{
    public class DTOtoVM : Profile
    {
        public DTOtoVM()
        {
            CreateMap<CategoryDTO, UpdateCategoryVM>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.Name));
            CreateMap<AccountDTO, LoginVM>()
                .ForMember(x => x.UserName, y => y.MapFrom(e => e.UserName))
                .ForMember(x => x.Password, y => y.MapFrom(e => e.Password));

            CreateMap<LoginVM, AccountDTO>();
                
        }
    }
}

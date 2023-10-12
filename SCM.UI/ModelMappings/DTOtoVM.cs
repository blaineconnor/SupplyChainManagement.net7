using AutoMapper;
using SCM.UI.Models.DTOs.Categories;
using SCM.UI.Models.RequestModels.Categories;

namespace SCM.UI.ModelMappings
{
    public class DTOtoVM : Profile
    {
        public DTOtoVM()
        {
            CreateMap<CategoryDTO, UpdateCategoryVM>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.Name));
        }
    }
}

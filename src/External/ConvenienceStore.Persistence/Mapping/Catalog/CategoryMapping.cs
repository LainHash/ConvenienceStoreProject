using AutoMapper;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.DataRecords.Catalog;

namespace ConvenienceStore.Persistence.Mapping.Catalog
{
    internal class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryRecord, Category>().ReverseMap();
            CreateMap<Category, CategoryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
        }
    }
}

using AutoMapper;
using ConvenienceStore.Contract.DTOs.Catalog;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.DataRecords.Catalog;

namespace ConvenienceStore.Persistence.Mapping.Catalog
{
    internal class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryRecord, Category>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}

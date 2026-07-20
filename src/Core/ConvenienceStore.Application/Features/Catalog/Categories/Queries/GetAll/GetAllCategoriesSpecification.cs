using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll
{
    public class GetAllCategoriesSpecification
        : BaseSpecification<Category>
    {
        public GetAllCategoriesSpecification(GetAllCategoriesQuery query)
        {
        }
    }
}

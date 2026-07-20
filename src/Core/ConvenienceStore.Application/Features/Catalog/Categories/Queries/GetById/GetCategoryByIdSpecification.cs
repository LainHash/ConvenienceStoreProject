using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById
{
    public class GetCategoryByIdSpecification
        : BaseSpecification<Category>
    {
        public GetCategoryByIdSpecification(GetCategoryByIdQuery query)
        {
            Criteria = c => string.Equals(c.PublicId, query.Id);

            EnableSoftDeleteFilter();
        }
    }
}

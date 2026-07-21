using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById
{
    public class GetBrandByIdSpecification
        : BaseSpecification<Brand>
    {
        public GetBrandByIdSpecification(GetBrandByIdQuery query)
        {
            Criteria = x => string.Equals(x.PublicId, query.Id);
            EnableSoftDeleteFilter();
        }
    }
}

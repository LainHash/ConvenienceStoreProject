using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    public class GetAllProductSpecification
        : BaseSpecification<Product>
    {
        public GetAllProductSpecification(GetAllProductQuery query)
        {
            EnableSoftDeleteFilter();
        }
    }
}

using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    public class GetAllProductSpecification
        : BaseSpecification<Product>
    {
        public GetAllProductSpecification(GetAllProductQuery query)
        {
            AddInclude(x => x.ProductStock);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);

            EnableSoftDeleteFilter();
        }
    }
}

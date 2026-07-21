using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById
{
    public class GetProductByIdSpecification
        : BaseSpecification<Product>
    {
        public GetProductByIdSpecification(GetProductByIdQuery query)
        {
            Criteria = x => string.Equals(x.PublicId, query.Id);
            
            AddInclude(x => x.ProductStock);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);

            EnableSoftDeleteFilter();
        }
    }
}

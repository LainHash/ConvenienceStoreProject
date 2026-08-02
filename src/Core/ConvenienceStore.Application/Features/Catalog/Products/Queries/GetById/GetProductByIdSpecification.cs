using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById
{
    public class GetProductByIdSpecification
        : BaseSpecification<Product>
    {
        public GetProductByIdSpecification(GetProductByIdQuery query)
        {
            Criteria = x => string.Equals(x.PublicId, query.Id);
            
            AddInclude(x => x.ProductStocks);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddIncludeAggregator(x => x.Include(p => p.ProductImages)
                                        .ThenInclude((ProductImage pi) => pi.Image));

            EnableSoftDeleteFilter();
        }
    }
}

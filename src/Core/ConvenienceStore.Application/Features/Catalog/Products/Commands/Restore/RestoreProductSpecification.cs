using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore
{
    public class RestoreProductSpecification
        : BaseSpecification<Product>
    {
        public RestoreProductSpecification(RestoreProductCommand command)
        {
            Criteria = p => string.Equals(p.PublicId, command.Id);
        }
    }
}

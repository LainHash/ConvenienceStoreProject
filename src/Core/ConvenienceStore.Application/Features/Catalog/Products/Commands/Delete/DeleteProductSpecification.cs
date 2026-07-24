using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete
{
    public class DeleteProductSpecification
        : BaseSpecification<Product>
    {
        public DeleteProductSpecification(DeleteProductCommand command)
        {
            Criteria = p => string.Equals(p.PublicId, command.Id);
        }
    }
}

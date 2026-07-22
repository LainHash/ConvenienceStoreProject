using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Update
{
    public class UpdateProductSpecification
        : BaseSpecification<Product>
    {
        public UpdateProductRequest Body { get; set; }
        public UpdateProductSpecification(UpdateProductCommand command)
        {
            Criteria = p => string.Equals(p.PublicId, command.Id);
            Body = command.Body;

            AddInclude(x => x.ProductStock);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
}

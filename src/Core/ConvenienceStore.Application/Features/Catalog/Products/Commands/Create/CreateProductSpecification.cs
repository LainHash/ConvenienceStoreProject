using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Create
{
    public class CreateProductSpecification
        : BaseSpecification<Product>
    {
        public CreateProductRequest Body { get; set; }
        public CreateProductSpecification(CreateProductCommand command)
        {
            Body = command.Body;

            AddInclude(x => x.ProductStock);
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }

        public void ApplyCriteria(int id)
        {
            Criteria = p => p.Id == id;
        }
    }
}

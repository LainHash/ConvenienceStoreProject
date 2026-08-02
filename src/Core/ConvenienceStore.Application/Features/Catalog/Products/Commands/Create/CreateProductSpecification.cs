using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Create
{
    public class CreateProductSpecification
        : BaseSpecification<Product>
    {
        public CreateProductRequest Body { get; set; }
        public CreateProductSpecification(CreateProductCommand command)
        {
            Body = command.Body;

            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddIncludeAggregator(x => x.Include(p => p.ProductImages)
                                        .ThenInclude((ProductImage pi) => pi.Image));
        }

        public void ApplyCriteria(int id)
        {
            Criteria = p => p.Id == id;
        }
    }
}

using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class ProductService : IProductService
    {
        public Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(GetAllProductSpecification specification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

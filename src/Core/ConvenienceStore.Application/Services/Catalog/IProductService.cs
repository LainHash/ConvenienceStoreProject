using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;

namespace ConvenienceStore.Application.Services.Catalog
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(
            GetAllProductSpecification specification,
            CancellationToken cancellationToken);
        Task<Result<ProductResponse>> GetByIdAsync(GetProductByIdSpecification specification, CancellationToken cancellationToken);
        Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken);
        Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken);
    }
}

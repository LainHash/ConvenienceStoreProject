using ConvenienceStore.Application.Features.Catalog.Products.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;

namespace ConvenienceStore.Application.Services.Catalog
{
    public interface IProductService
    {
        Task<PageResult<IEnumerable<ProductResponse>>> GetAllAsync(
            GetAllProductSpecification specification,
            CancellationToken cancellationToken);
        Task<Result<ProductResponse>> GetByIdAsync(
            GetProductByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<ProductResponse>> CreateAsync(
            CreateProductSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<ProductResponse>> UpdateAsync(
            UpdateProductSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<object>> DeleteAsync(
            DeleteProductSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<object>> RestoreAsync(
            RestoreProductSpecification specification,
            CancellationToken cancellationToken);
    }
}

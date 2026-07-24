using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;

namespace ConvenienceStore.Application.Services.Catalog
{
    public interface IBrandService
    {
        Task<PageResult<IEnumerable<BrandResponse>>> GetAllAsync(GetAllBrandsSpecification specification, CancellationToken cancellationToken);
        Task<Result<BrandResponse>> GetByIdAsync(GetBrandByIdSpecification specification, CancellationToken cancellationToken);
        Task<Result<BrandResponse>> CreateAsync(CreateBrandRequest request, CancellationToken cancellationToken);
        Task<Result<BrandResponse>> UpdateAsync(UpdateBrandSpecification specification, CancellationToken cancellationToken);
        Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken);
        Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken);
    }
}

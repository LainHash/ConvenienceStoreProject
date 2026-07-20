using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;

namespace ConvenienceStore.Application.Services.Catalog
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(
            GetAllCategoriesSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CategoryResponse>> GetByIdAsync(
            GetCategoryByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CategoryResponse>> CreateAsync(
            CreateCategoryRequest request,
            CancellationToken cancellationToken);
    }
}

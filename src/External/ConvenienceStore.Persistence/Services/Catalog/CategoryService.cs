using AutoMapper;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(
            GetAllCategoriesSpecification specification,
            CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ToListAsync(specification, cancellationToken);
            if (!categories.Any())
            {
                return Result<IEnumerable<CategoryResponse>>
                    .Fail(Error<Category>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Result<IEnumerable<CategoryResponse>>
                .Succeed(response, Success<Category>.Retrieved);
        }

        public async Task<Result<CategoryResponse>> GetByIdAsync(GetCategoryByIdSpecification specification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification, cancellationToken);
            if (category is null)
            {
                return Result<CategoryResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.InternalServerError);
            }

            var response = _mapper.Map<CategoryResponse>(category);
            return Result<CategoryResponse>
                .Succeed(response, Success<Category>.Retrieved);
        }
    }
}

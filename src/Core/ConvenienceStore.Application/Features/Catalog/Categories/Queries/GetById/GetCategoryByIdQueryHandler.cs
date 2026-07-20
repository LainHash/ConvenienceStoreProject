using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById
{
    internal class GetCategoryByIdQueryHandler
        : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCategoryByIdSpecification(request);
            var response = await _categoryService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}

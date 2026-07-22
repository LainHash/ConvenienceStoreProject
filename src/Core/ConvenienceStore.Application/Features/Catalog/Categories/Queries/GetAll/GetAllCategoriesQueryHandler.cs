using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll
{
    internal class GetAllCategoriesQueryHandler
        : IRequestHandler<GetAllCategoriesQuery, PageResult<IEnumerable<CategoryResponse>>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<PageResult<IEnumerable<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllCategoriesSpecification(request);
            var response = await _categoryService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

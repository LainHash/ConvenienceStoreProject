using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Update
{
    internal class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand, Result<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateCategorySpecification(request);
            var response = await _categoryService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}

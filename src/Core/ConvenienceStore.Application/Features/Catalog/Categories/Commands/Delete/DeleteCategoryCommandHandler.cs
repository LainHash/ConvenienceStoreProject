using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, Result<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryResponse>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

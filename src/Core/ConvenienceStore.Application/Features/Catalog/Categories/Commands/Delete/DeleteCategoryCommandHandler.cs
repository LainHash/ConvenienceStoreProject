using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, Result<object>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete
{
    internal class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, Result<object>>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<object>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _productService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

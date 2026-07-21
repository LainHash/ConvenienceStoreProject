using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore
{
    internal class RestoreProductCommandHandler
        : IRequestHandler<RestoreProductCommand, Result<object>>
    {
        private readonly IProductService _productService;

        public RestoreProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<object>> Handle(RestoreProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _productService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

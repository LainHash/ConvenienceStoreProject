using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Update
{
    internal class UpdateProductCommandHandler(IProductService productService)
                : IRequestHandler<UpdateProductCommand, Result<ProductResponse>>
    {
        private readonly IProductService _productService = productService;

        public async Task<Result<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateProductSpecification(request);
            var response = await _productService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}

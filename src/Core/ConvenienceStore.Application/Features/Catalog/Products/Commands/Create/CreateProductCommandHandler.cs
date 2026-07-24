using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Create
{
    internal class CreateProductCommandHandler(IProductService productService)
                : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
    {
        private readonly IProductService _productService = productService;

        public async Task<Result<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateProductSpecification(request);
            var response = await _productService.CreateAsync(specification, cancellationToken);
            return response;
        }
    }
}

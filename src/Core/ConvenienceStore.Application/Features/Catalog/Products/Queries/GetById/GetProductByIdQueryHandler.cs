using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById
{
    internal class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetProductByIdSpecification(request);
            var response = await _productService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}

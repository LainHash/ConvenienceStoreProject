using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    internal class GetAllProductQueryHandler(IProductService productService)
                : IRequestHandler<GetAllProductQuery, PageResult<IEnumerable<ProductResponse>>>
    {
        private readonly IProductService _productService = productService;

        public async Task<PageResult<IEnumerable<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllProductSpecification(request);
            var response = await _productService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

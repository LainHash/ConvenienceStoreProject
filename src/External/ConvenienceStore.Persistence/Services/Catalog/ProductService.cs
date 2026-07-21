using AutoMapper;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class ProductService : IProductService
    {
        private readonly IProductRespository _productRespository;
        private readonly IMapper _mapper;

        public ProductService(
            IMapper mapper,
            IProductRespository productRespository)
        {
            _mapper = mapper;
            _productRespository = productRespository;
        }

        public async Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(
            GetAllProductSpecification specification,
            CancellationToken cancellationToken)
        {
            var products = await _productRespository.ToListAsync(specification, cancellationToken);
            if (!products.Any())
            {
                return Result<IEnumerable<ProductResponse>>
                    .Fail(Error<Product>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Result<IEnumerable<ProductResponse>>
                .Succeed(response, Success<Product>.Retrieved);
        }
    }
}

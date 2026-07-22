using AutoMapper;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IMapper mapper,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<Result<IEnumerable<ProductResponse>>> GetAllAsync(
            GetAllProductSpecification specification,
            CancellationToken cancellationToken)
        {
            var products = await _productRepository.ToListAsync(specification, cancellationToken);
            if (!products.Any())
            {
                return Result<IEnumerable<ProductResponse>>
                    .Fail(Error<Product>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Result<IEnumerable<ProductResponse>>
                .Succeed(response, Success<Product>.Retrieved);
        }

        public async Task<Result<ProductResponse>> GetByIdAsync(
            GetProductByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(specification, cancellationToken);
            if (product is null)
            {
                return Result<ProductResponse>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<ProductResponse>(product);
            return Result<ProductResponse>
                .Succeed(response, Success<Product>.Retrieved);
        }

        public async Task<Result<ProductResponse>> CreateAsync(
            CreateProductSpecification specification,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(specification.Body.CategoryId, cancellationToken);
            if(category is null)
            {
                return Result<ProductResponse>
                    .Fail(Error<Category>.NotFound, HttpStatusCode.NotFound);
            }

            var brand = await _brandRepository.FindAsync(specification.Body.BrandId, cancellationToken);
            if (brand is null)
            {
                return Result<ProductResponse>
                    .Fail(Error<Brand>.NotFound, HttpStatusCode.NotFound);
            }

            var product = Product.Create(category.Id, brand.Id);
            _mapper.Map(specification.Body, product);
            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            throw new NotImplementedException();
        }

        public async Task<Result<object>> DeleteAsync(
            DeleteProductSpecification specification,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(specification, cancellationToken);
            if (product is null)
            {
                return Result<object>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.InternalServerError);
            }

            if (product.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Product>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            product.SoftDelete();
            product.ProductStock.SoftDelete();
            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Product>.Deleted, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RestoreAsync(
            RestoreProductSpecification specification,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(specification, cancellationToken);
            if (product is null)
            {
                return Result<object>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.InternalServerError);
            }

            if (!product.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Product>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            product.Restore();
            product.ProductStock.Restore();
            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Product>.Restored, HttpStatusCode.Accepted);
        }
    }
}

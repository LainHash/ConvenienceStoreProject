using AutoMapper;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Catalog
{
    internal class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(
            IBrandRepository brandRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PageResult<IEnumerable<BrandResponse>>> GetAllAsync(
            GetAllBrandsSpecification specification,
            CancellationToken cancellationToken)
        {
            var totalItems = await _brandRepository.CountAsync(specification, cancellationToken);

            var brands = await _brandRepository.ToListAsync(specification, cancellationToken);
            if (!brands.Any())
            {
                return PageResult<IEnumerable<BrandResponse>>
                    .Fail(Error<Brand>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<BrandResponse>>(brands);
            return PageResult<IEnumerable<BrandResponse>>
                .Succeed(response, Success<Brand>.Retrieved, totalItems, specification.Skip, specification.Take);
        }

        public async Task<Result<BrandResponse>> GetByIdAsync(GetBrandByIdSpecification specification, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FindAsync(specification, cancellationToken);
            if (brand is null)
            {
                return Result<BrandResponse>
                    .Fail(Error<Brand>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<BrandResponse>(brand);
            return Result<BrandResponse>
                .Succeed(response, Success<Brand>.Retrieved);
        }

        public async Task<Result<BrandResponse>> CreateAsync(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            var existingBrand = await _brandRepository.FindNameAsync(request.Name, cancellationToken);
            if (existingBrand is not null)
            {
                return Result<BrandResponse>
                    .Fail(Error<Brand>.ExistedName, HttpStatusCode.Conflict);
            }

            var brand = new Brand();
            _mapper.Map(request, brand);
            _brandRepository.Add(brand);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<BrandResponse>(brand);
            return Result<BrandResponse>
                .Succeed(response, Success<Brand>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<BrandResponse>> UpdateAsync(UpdateBrandSpecification specification, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FindAsync(specification, cancellationToken);
            if (brand is null)
            {
                return Result<BrandResponse>
                    .Fail(Error<Brand>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, brand);
            _brandRepository.Update(brand);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<BrandResponse>(brand);
            return Result<BrandResponse>
                .Succeed(response, Success<Brand>.Updated, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FindAsync(id, cancellationToken);
            if (brand is null)
            {
                return Result<object>
                    .Fail(Error<Brand>.NotFound, HttpStatusCode.NotFound);
            }

            if (brand.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Brand>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            brand.SoftDelete();
            _brandRepository.Update(brand);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Brand>.Deleted, HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FindAsync(id, cancellationToken);
            if (brand is null)
            {
                return Result<object>
                    .Fail(Error<Brand>.NotFound, HttpStatusCode.NotFound);
            }

            if (!brand.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Brand>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            brand.Restore();
            _brandRepository.Update(brand);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Brand>.Restored, HttpStatusCode.Accepted);
        }
    }
}

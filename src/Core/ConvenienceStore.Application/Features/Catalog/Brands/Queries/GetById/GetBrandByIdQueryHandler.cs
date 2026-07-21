using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById
{
    internal class GetBrandByIdQueryHandler
        : IRequestHandler<GetBrandByIdQuery, Result<BrandResponse>>
    {
        private readonly IBrandService _brandService;

        public GetBrandByIdQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<BrandResponse>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetBrandByIdSpecification(request);
            var response = await _brandService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}

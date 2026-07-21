using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll
{
    internal class GetAllBrandsQueryHandler
        : IRequestHandler<GetAllBrandsQuery, Result<IEnumerable<BrandResponse>>>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandsQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<IEnumerable<BrandResponse>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllBrandsSpecification(request);
            var response = await _brandService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

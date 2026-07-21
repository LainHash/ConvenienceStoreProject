using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update
{
    internal class UpdateBrandCommandHandler
        : IRequestHandler<UpdateBrandCommand, Result<BrandResponse>>
    {
        private readonly IBrandService _brandService;

        public UpdateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<BrandResponse>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateBrandSpecification(request);
            var response = await _brandService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Create
{
    internal class CreateBrandCommandHandler
        : IRequestHandler<CreateBrandCommand, Result<BrandResponse>>
    {
        private readonly IBrandService _brandService;

        public CreateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<BrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var response = await _brandService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}

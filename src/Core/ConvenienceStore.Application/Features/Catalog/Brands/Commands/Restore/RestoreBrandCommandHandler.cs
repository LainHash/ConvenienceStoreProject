using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Restore
{
    internal class RestoreBrandCommandHandler
        : IRequestHandler<RestoreBrandCommand, Result<object>>
    {
        private readonly IBrandService _brandService;

        public RestoreBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<object>> Handle(RestoreBrandCommand request, CancellationToken cancellationToken)
        {
            var response = await _brandService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Delete
{
    internal class DeleteBrandCommandHandler
        : IRequestHandler<DeleteBrandCommand, Result<object>>
    {
        private readonly IBrandService _brandService;

        public DeleteBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Result<object>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var response = await _brandService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}

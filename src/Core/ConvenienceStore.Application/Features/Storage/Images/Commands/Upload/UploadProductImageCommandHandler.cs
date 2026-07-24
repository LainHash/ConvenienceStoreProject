using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Storage;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using MediatR;

namespace ConvenienceStore.Application.Features.Storage.Images.Commands.Upload
{
    internal class UploadProductImageCommandHandler(IImageService imageService)
                : IRequestHandler<UploadProductImageCommand, Result<UploadImageResponse>>
    {
        private readonly IImageService _imageService = imageService;

        public async Task<Result<UploadImageResponse>> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            var specification = new UploadProductImageSpecification(request);
            var response = await _imageService.UploadProductImageAsync(specification, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Features.Storage.Images.Commands.Upload;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Storage.Images;

namespace ConvenienceStore.Application.Services.Storage
{
    public interface IImageService
    {
        Task<Result<UploadImageResponse>> UploadProductImageAsync(
            UploadProductImageSpecification specification,
            CancellationToken cancellationToken);
    }
}

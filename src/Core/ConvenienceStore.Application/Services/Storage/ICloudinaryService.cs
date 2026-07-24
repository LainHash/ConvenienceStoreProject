using ConvenienceStore.Application.Models.Results;

namespace ConvenienceStore.Application.Services.Storage
{
    public interface ICloudinaryService
    {
        Task<CloudinaryUploadResult> UploadAsync(
            Stream fileStream,
            string fileName,
            string? folder = null,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(
            string publicId, 
            CancellationToken cancellationToken = default);
    }
}

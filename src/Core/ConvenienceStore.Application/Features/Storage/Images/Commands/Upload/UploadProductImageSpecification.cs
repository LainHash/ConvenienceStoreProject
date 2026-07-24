using ConvenienceStore.Contract.DTOs.Storage.Images;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Storage.Images.Commands.Upload
{
    public class UploadProductImageSpecification : BaseSpecification<Image>
    {
        public string ProductId { get; }
        public Stream FileStream { get; }
        public string FileName { get; }
        public UploadImageRequest Metadata { get; }

        public UploadProductImageSpecification(UploadProductImageCommand command)
        {
            ProductId = command.ProductId;
            FileStream = command.FileStream;
            FileName = command.FileName;
            Metadata = command.Metadata;
        }
    }
}

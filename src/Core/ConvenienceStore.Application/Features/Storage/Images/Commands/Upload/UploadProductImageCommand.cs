using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using MediatR;

namespace ConvenienceStore.Application.Features.Storage.Images.Commands.Upload
{
    public record UploadProductImageCommand(string ProductId,
                                            Stream FileStream,
                                            string FileName,
                                            UploadImageRequest Metadata) 
        : IRequest<Result<UploadImageResponse>>
    {
    }
}

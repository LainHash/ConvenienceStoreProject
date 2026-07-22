using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Update
{
    public record UpdateProductCommand(string Id, UpdateProductRequest Body)
        : IRequest<Result<ProductResponse>>
    {
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Create
{
    public record CreateProductCommand(CreateProductRequest Body)
        : IRequest<Result<ProductResponse>>
    {
    }
}

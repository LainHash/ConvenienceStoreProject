using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete
{
    public record DeleteProductCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

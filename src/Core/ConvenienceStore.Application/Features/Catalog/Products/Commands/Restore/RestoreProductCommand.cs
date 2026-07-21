using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore
{
    public record RestoreProductCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Delete
{
    public record DeleteBrandCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

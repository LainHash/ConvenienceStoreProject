using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Restore
{
    public record RestoreBrandCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

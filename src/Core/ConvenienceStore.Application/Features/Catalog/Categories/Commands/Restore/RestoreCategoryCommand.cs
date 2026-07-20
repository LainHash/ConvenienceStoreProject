using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Restore
{
    public record RestoreCategoryCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

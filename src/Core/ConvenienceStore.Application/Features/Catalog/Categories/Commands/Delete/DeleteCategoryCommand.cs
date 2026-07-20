using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}

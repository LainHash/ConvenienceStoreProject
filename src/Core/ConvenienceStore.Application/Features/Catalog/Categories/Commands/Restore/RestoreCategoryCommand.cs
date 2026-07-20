using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Restore
{
    public record RestoreCategoryCommand(string Id)
        : IRequest<Result<CategoryResponse>>
    {
    }
}

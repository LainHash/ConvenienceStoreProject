using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Update
{
    public record UpdateCategoryCommand(string id, UpdateCategoryRequest Body)
        : IRequest<Result<CategoryResponse>>
    {
    }
}

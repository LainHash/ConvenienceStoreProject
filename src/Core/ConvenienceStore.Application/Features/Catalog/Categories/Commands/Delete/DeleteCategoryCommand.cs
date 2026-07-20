using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(string Id)
        : IRequest<Result<CategoryResponse>>
    {
    }
}

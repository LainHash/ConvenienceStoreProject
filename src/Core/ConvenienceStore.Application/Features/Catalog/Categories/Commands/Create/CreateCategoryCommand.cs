using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Commands.Create
{
    public record CreateCategoryCommand(CreateCategoryRequest Body)
        : IRequest<Result<CategoryResponse>>
    {
    }
}

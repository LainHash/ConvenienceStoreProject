using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById
{
    public record GetCategoryByIdQuery(string Id)
        : IRequest<Result<CategoryResponse>>
    {
    }
}

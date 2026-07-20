using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll
{
    public record GetAllCategoriesQuery
        : IRequest<Result<IEnumerable<CategoryResponse>>>
    {
    }
}

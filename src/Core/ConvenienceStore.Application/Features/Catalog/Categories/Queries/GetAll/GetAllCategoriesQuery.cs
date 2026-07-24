using ConvenienceStore.Application.Models;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll
{
    public record GetAllCategoriesQuery
        : PageQuery, IRequest<PageResult<IEnumerable<CategoryResponse>>>
    {
    }
}

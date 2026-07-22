using ConvenienceStore.Application.Models;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll
{
    public record GetAllBrandsQuery
        : PageQuery, IRequest<PageResult<IEnumerable<BrandResponse>>>
    {
    }
}

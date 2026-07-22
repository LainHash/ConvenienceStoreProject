using ConvenienceStore.Application.Models;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    public record GetAllProductQuery(string CategoryName = "", string BrandName = "")
        : PageQuery, IRequest<PageResult<IEnumerable<ProductResponse>>>
    {
    }
}

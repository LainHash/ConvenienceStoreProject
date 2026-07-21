using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll
{
    public record GetAllProductQuery
        : IRequest<Result<IEnumerable<ProductResponse>>>
    {
    }
}

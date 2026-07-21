using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById
{
    public record GetProductByIdQuery(string Id)
        : IRequest<Result<ProductResponse>>
    {
    }
}

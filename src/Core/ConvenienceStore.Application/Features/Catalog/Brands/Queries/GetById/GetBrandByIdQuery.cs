using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById
{
    public record GetBrandByIdQuery(string Id)
        : IRequest<Result<BrandResponse>>
    {
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update
{
    public record UpdateBrandCommand(string Id, UpdateBrandRequest Body)
        : IRequest<Result<BrandResponse>>
    {
    }
}

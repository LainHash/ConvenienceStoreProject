using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;

namespace ConvenienceStore.Application.Features.Catalog.Brands.Commands.Create
{
    public record CreateBrandCommand(CreateBrandRequest Body)
        : IRequest<Result<BrandResponse>>
    {
    }
}

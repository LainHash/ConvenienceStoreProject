using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName
{
    public record GetDiscountByNameQuery(string Name)
        : IRequest<Result<DiscountResponse>>
    {
    }
}

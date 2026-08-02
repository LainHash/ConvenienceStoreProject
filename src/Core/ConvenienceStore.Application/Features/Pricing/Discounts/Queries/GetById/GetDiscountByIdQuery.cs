using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById
{
    public record GetDiscountByIdQuery(string Id)
        : IRequest<Result<DiscountResponse>>
    {
    }
}

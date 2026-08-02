using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll
{
    public record GetAllDiscountsQuery()
        : IRequest<Result<IEnumerable<DiscountResponse>>>
    {
    }
}
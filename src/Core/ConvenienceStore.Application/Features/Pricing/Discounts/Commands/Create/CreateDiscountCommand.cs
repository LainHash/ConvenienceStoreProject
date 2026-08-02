using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Commands.Create
{
    public record CreateDiscountCommand(CreateDiscountRequest Body)
        : IRequest<Result<DiscountResponse>>
    {
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById
{
    internal class GetDiscountByIdQueryHandler(IDiscountService discountService)
                : IRequestHandler<GetDiscountByIdQuery, Result<DiscountResponse>>
    {
        private readonly IDiscountService _discountService = discountService;

        public async Task<Result<DiscountResponse>> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetDiscountByIdSpecification(request);
            var response = await _discountService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}

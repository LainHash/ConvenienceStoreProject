using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName
{
    internal class GetDiscountByNameQueryHandler(IDiscountService discountService)
                : IRequestHandler<GetDiscountByNameQuery, Result<DiscountResponse>>
    {
        private readonly IDiscountService _discountService = discountService;

        public async Task<Result<DiscountResponse>> Handle(GetDiscountByNameQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetDiscountByNameSpecification(request);
            var response = await _discountService.GetByNameAsync(specification, cancellationToken);
            return response;
        }
    }
}

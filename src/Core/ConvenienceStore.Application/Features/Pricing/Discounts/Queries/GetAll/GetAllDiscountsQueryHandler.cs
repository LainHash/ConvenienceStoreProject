using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll
{
    internal class GetAllDiscountsQueryHandler(IDiscountService discountService)
                : IRequestHandler<GetAllDiscountsQuery, Result<IEnumerable<DiscountResponse>>>
    {
        private readonly IDiscountService _discountService = discountService;

        public async Task<Result<IEnumerable<DiscountResponse>>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllDiscountsSpecification(request);
            var response = await _discountService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

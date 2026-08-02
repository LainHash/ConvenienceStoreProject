using AutoMapper;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Repositories.Pricing;

namespace ConvenienceStore.Persistence.Services.Pricing
{
    internal class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        private readonly IMapper _mapper;

        public DiscountService(
            IDiscountRepository discountRepository,
            IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<DiscountResponse>>> GetAllAsync(
            GetAllDiscountsSpecification specification,
            CancellationToken cancellationToken)
        {
            var discounts = await _discountRepository.ToListAsync(specification, cancellationToken);
            if (!discounts.Any())
            {
                return Result<IEnumerable<DiscountResponse>>
                    .Fail(Error<Discount>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<DiscountResponse>>(discounts);
            return Result<IEnumerable<DiscountResponse>>
                .Succeed(response, Success<Discount>.Retrieved);
        }
    }
}

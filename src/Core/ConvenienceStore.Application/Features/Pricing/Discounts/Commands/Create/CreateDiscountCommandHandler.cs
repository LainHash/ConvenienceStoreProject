using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Commands.Create
{
    internal class CreateDiscountCommandHandler(IDiscountService discountService)
                : IRequestHandler<CreateDiscountCommand, Result<DiscountResponse>>
    {
        private readonly IDiscountService _discountService = discountService;

        public async Task<Result<DiscountResponse>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var response = await _discountService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}

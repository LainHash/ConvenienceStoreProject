using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;

namespace ConvenienceStore.Application.Services.Pricing
{
    public interface IDiscountService
    {
        Task<Result<IEnumerable<DiscountResponse>>> GetAllAsync(
            GetAllDiscountsSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<DiscountResponse>> GetByIdAsync(
            GetDiscountByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<DiscountResponse>> GetByNameAsync(
            GetDiscountByNameSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<DiscountResponse>> CreateAsync(
            CreateDiscountRequest body,
            CancellationToken cancellationToken);
    }
}

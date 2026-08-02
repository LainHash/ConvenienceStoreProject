using AutoMapper;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Pricing;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Repositories.Pricing;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Pricing
{
    internal class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(
            IDiscountRepository discountRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<Result<DiscountResponse>> GetByIdAsync(
            GetDiscountByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var discount = await _discountRepository.FindAsync(specification, cancellationToken);
            if(discount is null)
            {
                return Result<DiscountResponse>
                    .Fail(Error<Discount>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<DiscountResponse>(discount);
            return Result<DiscountResponse>
                .Succeed(response, Success<Discount>.Retrieved);
        }

        public async Task<Result<DiscountResponse>> GetByNameAsync(
            GetDiscountByNameSpecification specification,
            CancellationToken cancellationToken)
        {
            var discount = await _discountRepository.FindAsync(specification, cancellationToken);
            if (discount is null)
            {
                return Result<DiscountResponse>
                    .Fail(Error<Discount>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<DiscountResponse>(discount);
            return Result<DiscountResponse>
                .Succeed(response, Success<Discount>.Retrieved);
        }

        public async Task<Result<DiscountResponse>> CreateAsync(
            CreateDiscountRequest body,
            CancellationToken cancellationToken)
        {
            var discount = new Discount();
            _mapper.Map(body, discount);
            _discountRepository.Add(discount);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<DiscountResponse>(discount);
            return Result<DiscountResponse>
                .Succeed(response, Success<Discount>.Created, HttpStatusCode.Created);
        }
    }
}

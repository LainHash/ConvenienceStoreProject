using AutoMapper;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.Guest;
using System.Net;

namespace ConvenienceStore.Persistence.Services.CartAndWishlist
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task InitializeAsync(int customerId, CancellationToken cancellationToken)
        {
            var cart = new Cart(customerId);
            _cartRepository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result<CartResponse>> GetByCustomerIdAsync(
            GetCartByCustomerIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindAsync(specification.CustomerId, cancellationToken);
            if (customer is null)
            {
                return Result<CartResponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var cart = await _cartRepository.FindAsync(specification, cancellationToken);
            if(cart is null)
            {
                await InitializeAsync(customer.Id, cancellationToken);
            }

            var createdCart = await _cartRepository.FindAsync(specification, cancellationToken);

            var response = _mapper.Map<CartResponse>(createdCart);
            return Result<CartResponse>
                .Succeed(response, Success<Cart>.Retrieved);
        }
    }
}

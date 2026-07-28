using AutoMapper;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Domain.Repositories.Identity;
using System.Net;

namespace ConvenienceStore.Persistence.Services.CartAndWishlist
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<Cart> InitializeAsync(int customerId, CancellationToken cancellationToken)
        {
            var cart = new Cart(customerId);
            _cartRepository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return cart;
        }

        public async Task<Cart> InitializeAsync(string sessionId, CancellationToken cancellationToken)
        {
            var cart = new Cart(sessionId);
            _cartRepository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return cart;
        }

        public async Task<Result<CartResponse>> GetByCustomerIdAsync(
            GetCartByCustomerIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(specification.UserId, cancellationToken);
            if (user is null)
            {
                return Result<CartResponse>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            var customer = await _customerRepository.FindByUserAsync(user.Id, cancellationToken);
            if (customer is null)
            {
                return Result<CartResponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var cart = await _cartRepository.FindAsync(specification, cancellationToken);
            cart ??= await InitializeAsync(customer.Id, cancellationToken);

            var response = _mapper.Map<CartResponse>(cart);
            return Result<CartResponse>
                    .Succeed(response, Success<Cart>.Retrieved);
        }

        public Task<Result<CartResponse>> AddItemAsync()
        {
            throw new NotImplementedException();
        }
    }
}

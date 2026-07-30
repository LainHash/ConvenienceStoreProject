using AutoMapper;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Domain.Repositories.Inventory;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net;

namespace ConvenienceStore.Persistence.Services.CartAndWishlist
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductStockRepository _productStockRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CartService> _logger;

        public CartService(
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IProductRepository productRepository,
            ICartItemRepository cartItemRepository,
            IProductStockRepository productStockRepository,
            ILogger<CartService> logger)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _productStockRepository = productStockRepository;
            _logger = logger;
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

            var cart = await GetOrCreateAsync(specification, () => new Cart(customer.Id), cancellationToken);

            var response = _mapper.Map<CartResponse>(cart);
            return Result<CartResponse>
                    .Succeed(response, Success<Cart>.Retrieved);
        }

        public async Task<Result<CartResponse>> GetBySessionIdAsync(
            GetCartBySessionIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var cart = await GetOrCreateAsync(specification, () => new Cart(specification.SessionId), cancellationToken);

            var response = _mapper.Map<CartResponse>(cart);
            return Result<CartResponse>
                    .Succeed(response, Success<Cart>.Retrieved);
        }

        public async Task<Result<CartResponse>> AddItemAsync(
            AddCartItemSpecification specification,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(specification.Body.UserId) && string.IsNullOrEmpty(specification.Body.SessionId))
            {
                return Result<CartResponse>
                        .Fail("Either user id or session id must be not null.", HttpStatusCode.NotFound);
            }

            var cart = new Cart();
            if (!string.IsNullOrEmpty(specification.Body.UserId))
            {
                var user = await _userRepository.FindAsync(specification.Body.UserId, cancellationToken);
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

                cart = await GetOrCreateAsync(specification, () => new Cart(customer.Id), cancellationToken);
            }
            else if (!string.IsNullOrEmpty(specification.Body.SessionId))
            {
                cart = await GetOrCreateAsync(specification, () => new Cart(specification.Body.SessionId), cancellationToken);
            }

            var product = await _productRepository.FindAsync(specification.Body.ProductId, cancellationToken);
            if (product is null)
            {
                return Result<CartResponse>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.NotFound);
            }

            var productStock = await _productStockRepository.FindByProductAsync(product.Id, cancellationToken);
            if (productStock!.QuantityOnHand < 1)
            {
                return Result<CartResponse>
                    .Fail("Out of stock.", HttpStatusCode.UnprocessableEntity);
            }

            var cartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (cartItem is null)
            {
                cartItem = new CartItem(product.Id);
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.ChangeQuantity();
            }

            try
            {
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex,
                    "Concurrency conflict when adding item to cart.");

                return Result<CartResponse>
                    .Fail("Cart was modified by another request. Please try again.",
                          HttpStatusCode.Conflict);
            }

            specification.ApplyCriteria(cart.Id);
            var addedItemCart = await _cartRepository.FindAsync(specification, cancellationToken);

            var response = _mapper.Map<CartResponse>(addedItemCart);
            return Result<CartResponse>
                    .Succeed(response, Success<CartItem>.Added, HttpStatusCode.Created);
        }

        public async Task<Result<CartResponse>> UpdateItemQuantityAsync(
            UpdateCartItemQuantitySpecification specification,
            CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindAsync(specification, cancellationToken);
            if (cart is null)
            {
                return Result<CartResponse>
                    .Fail(Error<CartItem>.NotFound, HttpStatusCode.NotFound);
            }

            var cartItem = cart.CartItems.First(x => string.Equals(x.PublicId, specification.CartItemId));

            var productStock = await _productStockRepository.FindByProductAsync(cartItem.Product.Id, cancellationToken);

            try
            {
                cart.ChangeItemQuantity(specification.CartItemId, specification.Body.Amount, productStock!.QuantityOnHand);
            }
            catch (Exception ex)
            {
                return Result<CartResponse>
                    .Fail(ex.Message, HttpStatusCode.UnprocessableEntity);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CartResponse>(cart);
            return Result<CartResponse>
                    .Succeed(response, Success<CartItem>.Updated);
        }

        private async Task<Cart> InitializeAsync(
            Func<Cart> factory,
            CancellationToken cancellationToken)
        {
            var cart = factory();

            _cartRepository.Add(cart);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return cart;
        }

        private async Task<Cart> GetOrCreateAsync(
            ISpecification<Cart> specification,
            Func<Cart> factory,
            CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindAsync(specification, cancellationToken);

            if (cart is not null)
                return cart;

            return await InitializeAsync(factory, cancellationToken);
        }
    }
}

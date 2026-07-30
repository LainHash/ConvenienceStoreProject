using AutoMapper;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Domain.Specifications;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ConvenienceStore.Persistence.Services.CartAndWishlist
{
    internal class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<WishlistService> _logger;

        public WishlistService(
            IWishlistRepository wishlistRepository,
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<WishlistService> logger,
            IProductRepository productRepository,
            IWishlistItemRepository wishlistItemRepository)
        {
            _wishlistRepository = wishlistRepository;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _productRepository = productRepository;
            _wishlistItemRepository = wishlistItemRepository;
        }

        public async Task<Result<WishlistResponse>> GetByCustomerIdAsync(
            GetWishlistByCustomerIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(specification.UserId, cancellationToken);
            if (user is null)
            {
                return Result<WishlistResponse>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            var customer = await _customerRepository.FindByUserAsync(user.Id, cancellationToken);
            if (customer is null)
            {
                return Result<WishlistResponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var wishlist = await GetOrCreateAsync(
                specification,
                () => new Wishlist(customer.Id),
                cancellationToken);

            var response = _mapper.Map<WishlistResponse>(wishlist);
            return Result<WishlistResponse>
                    .Succeed(response, Success<Wishlist>.Retrieved);
        }

        public async Task<Result<WishlistResponse>> GetBySessionIdAsync(
            GetWishlistBySessionIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var wishlist = await GetOrCreateAsync(
                specification,
                () => new Wishlist(specification.SessionId),
                cancellationToken);

            var response = _mapper.Map<WishlistResponse>(wishlist);
            return Result<WishlistResponse>
                    .Succeed(response, Success<Wishlist>.Retrieved);
        }

        private async Task<Wishlist> InitializeAsync(
            Func<Wishlist> factory,
            CancellationToken cancellationToken)
        {
            var wishlist = factory();

            _wishlistRepository.Add(wishlist);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return wishlist;
        }

        private async Task<Wishlist> GetOrCreateAsync(
            ISpecification<Wishlist> specification,
            Func<Wishlist> factory,
            CancellationToken cancellationToken)
        {
            var wishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);

            if (wishlist is not null)
                return wishlist;

            return await InitializeAsync(factory, cancellationToken);
        }

        public async Task<Result<WishlistResponse>> AddItemAsync(
            AddWishlistItemSpecification specification,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(specification.Body.UserId) && string.IsNullOrEmpty(specification.Body.SessionId))
            {
                return Result<WishlistResponse>
                        .Fail("Either user id or session id must be not null.", HttpStatusCode.NotFound);
            }

            var wishlist = new Wishlist();
            if (!string.IsNullOrEmpty(specification.Body.UserId))
            {
                var user = await _userRepository.FindAsync(specification.Body.UserId, cancellationToken);
                if (user is null)
                {
                    return Result<WishlistResponse>
                        .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
                }

                var customer = await _customerRepository.FindByUserAsync(user.Id, cancellationToken);
                if (customer is null)
                {
                    return Result<WishlistResponse>
                        .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
                }

                wishlist = await GetOrCreateAsync(specification, () => new Wishlist(customer.Id), cancellationToken);
            }
            else if (!string.IsNullOrEmpty(specification.Body.SessionId))
            {
                wishlist = await GetOrCreateAsync(specification, () => new Wishlist(specification.Body.SessionId), cancellationToken);
            }

            var product = await _productRepository.FindAsync(specification.Body.ProductId, cancellationToken);
            if (product is null)
            {
                return Result<WishlistResponse>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.NotFound);
            }

            var wishlistItem = wishlist.WishlistItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (wishlistItem is null)
            {
                wishlistItem = new WishlistItem(product.Id);
                _wishlistItemRepository.Add(wishlistItem);
                wishlist.WishlistItems.Add(wishlistItem);
            }
            else
            {
                return Result<WishlistResponse>
                    .Fail(Error<WishlistItem>.AlreadyAdded, HttpStatusCode.Conflict);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(wishlist.Id);
            var addedItemWishlist = await _wishlistRepository.FindAsync(specification, cancellationToken);
            var response = _mapper.Map<WishlistResponse>(addedItemWishlist);
            return Result<WishlistResponse>
                    .Succeed(response, Success<WishlistItem>.Added, HttpStatusCode.Created);
        }
    }
}

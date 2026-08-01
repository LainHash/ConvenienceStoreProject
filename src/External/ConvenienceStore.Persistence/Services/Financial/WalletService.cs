using AutoMapper;
using ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Financial;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Contract.DTOs.Financial;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Financial;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Financial;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Domain.Specifications;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Financial
{
    internal class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalletService(
            IWalletRepository walletRepository,
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<WalletResponse>> GetByUserIdAsync(
            GetWalletByUserIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(specification.UserId, cancellationToken);
            if (user is null)
            {
                return Result<WalletResponse>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            var customer = await _customerRepository.FindByUserAsync(user.Id, cancellationToken);
            if (customer is null)
            {
                return Result<WalletResponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var wallet = await GetOrCreateAsync(specification, () => new Wallet(customer.Id), cancellationToken);

            var response = _mapper.Map<WalletResponse>(wallet);
            return Result<WalletResponse>
                .Succeed(response, Success<Wallet>.Retrieved);
        }

        private async Task<Wallet> InitializeAsync(
            Func<Wallet> factory,
            CancellationToken cancellationToken)
        {
            var wallet = factory();
            _walletRepository.Add(wallet);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return wallet;
        }

        private async Task<Wallet> GetOrCreateAsync(
            ISpecification<Wallet> specification,
            Func<Wallet> factory,
            CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.FindAsync(specification, cancellationToken);

            if (wallet is not null)
                return wallet;

            return await InitializeAsync(factory, cancellationToken);
        }
    }
}

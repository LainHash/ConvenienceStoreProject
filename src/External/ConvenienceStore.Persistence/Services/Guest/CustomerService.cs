using AutoMapper;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Guest;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Repositories.Guest;

namespace ConvenienceStore.Persistence.Services.Guest
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CustomerResponse>>> GetAllAsync(
            GetAllCustomersSpecification specification,
            CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.ToListAsync(specification, cancellationToken);
            if (!customers.Any())
            {
                return Result<IEnumerable<CustomerResponse>>
                    .Fail(Error<Customer>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return Result<IEnumerable<CustomerResponse>>
                .Succeed(response, Success<Customer>.Retrieved);
        }
    }
}

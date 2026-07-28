using AutoMapper;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Guest;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Repositories.Guest;
using System.Net;

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

        public async Task<Result<CustomerResponse>> GetByUserIdAsync(
            GetCustomerByUserIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindAsync(specification, cancellationToken);
            if(customer is null)
            {
                return Result<CustomerResponse>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<CustomerResponse>(customer);
            return Result<CustomerResponse>
                .Succeed(response, Success<Customer>.Retrieved);
        }
    }
}

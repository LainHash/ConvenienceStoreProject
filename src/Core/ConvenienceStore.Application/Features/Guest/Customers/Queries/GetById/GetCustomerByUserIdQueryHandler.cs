using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Guest;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById
{
    internal class GetCustomerByUserIdQueryHandler(ICustomerService customerService)
                : IRequestHandler<GetCustomerByUserIdQuery, Result<CustomerResponse>>
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<Result<CustomerResponse>> Handle(GetCustomerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCustomerByUserIdSpecification(request);
            var response = await _customerService.GetByUserIdAsync(specification, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Guest;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll
{
    internal class GetAllCustomersQueryHandler(ICustomerService customerService)
                : IRequestHandler<GetAllCustomersQuery, Result<IEnumerable<CustomerResponse>>>
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<Result<IEnumerable<CustomerResponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllCustomersSpecification(request);
            var response = await _customerService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetByUserId
{
    public record GetCustomerByUserIdQuery(string UserId)
        : IRequest<Result<CustomerResponse>>
    {
    }
}

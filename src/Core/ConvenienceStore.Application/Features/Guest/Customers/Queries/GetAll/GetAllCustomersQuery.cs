using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll
{
    public record GetAllCustomersQuery
        : IRequest<Result<IEnumerable<CustomerResponse>>>
    {
    }
}

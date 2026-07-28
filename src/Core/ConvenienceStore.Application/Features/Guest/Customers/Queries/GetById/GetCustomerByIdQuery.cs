using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById
{
    public record GetCustomerByIdQuery(string Id)
        : IRequest<Result<CustomerResponse>>
    {
    }
}

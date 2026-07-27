using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Guest.Customers;

namespace ConvenienceStore.Application.Services.Guest
{
    public interface ICustomerService
    {
        Task<Result<IEnumerable<CustomerResponse>>> GetAllAsync(
            GetAllCustomersSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CustomerResponse>> GetByIdAsync(
            GetCustomerByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}

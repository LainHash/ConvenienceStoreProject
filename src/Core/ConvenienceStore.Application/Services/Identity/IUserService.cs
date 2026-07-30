using ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;

namespace ConvenienceStore.Application.Services.Identity
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserResponse>>> GetAllAsync(
            GetAllUsersSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<UserResponse>> GetByIdAsync(
            GetUserByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}

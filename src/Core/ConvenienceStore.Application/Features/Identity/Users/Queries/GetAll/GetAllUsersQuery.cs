using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll
{
    public record GetAllUsersQuery()
        : IRequest<Result<IEnumerable<UserResponse>>>
    {
    }
}

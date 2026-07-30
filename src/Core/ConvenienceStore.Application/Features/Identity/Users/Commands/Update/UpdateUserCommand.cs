using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.Update
{
    public record UpdateUserCommand(string Id, UpdateUserRequest Body)
        : IRequest<Result<UserResponse>>
    {
    }
}

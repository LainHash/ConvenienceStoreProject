using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ChangePassword
{
    public record ChangeUserPasswordCommand(string Id, ChangeUserPasswordRequest Body)
        : IRequest<Result<object>>
    {
    }
}

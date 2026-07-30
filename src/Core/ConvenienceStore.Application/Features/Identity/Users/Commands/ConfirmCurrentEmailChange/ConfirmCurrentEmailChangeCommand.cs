using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange
{
    public record ConfirmCurrentEmailChangeCommand(string UserId, ConfirmEmailChangeRequest Body)
        : IRequest<Result<object>>;
}

using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange
{
    public record ConfirmEmailChangeCommand(string UserId, ConfirmEmailChangeRequest Body)
        : IRequest<Result<object>>;
}

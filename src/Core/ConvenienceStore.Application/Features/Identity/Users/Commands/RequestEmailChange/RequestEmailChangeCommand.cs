using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange
{
    public record RequestEmailChangeCommand(string UserId, RequestEmailChangeRequest Body)
        : IRequest<Result<object>>;
}

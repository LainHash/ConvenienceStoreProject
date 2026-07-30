using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetById
{
    public record GetUserByIdQuery(string Id)
        : IRequest<Result<UserResponse>>
    {
    }
}

using ConvenienceStore.Contract.DTOs.Identity.Users;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.Update
{
    public class UpdateUserSpecification
        : BaseSpecification<User>
    {
        public UpdateUserRequest Body { get; set; }
        public UpdateUserSpecification(UpdateUserCommand command)
        {
            Criteria = u => string.Equals(u.PublicId, command.Id);
            Body = command.Body;
            AddInclude(x => x.Role);
        }
    }
}

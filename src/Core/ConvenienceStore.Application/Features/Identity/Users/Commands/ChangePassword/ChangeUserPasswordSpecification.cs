using ConvenienceStore.Contract.DTOs.Identity.Users;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ChangePassword
{
    public class ChangeUserPasswordSpecification
        : BaseSpecification<User>
    {
        public ChangeUserPasswordRequest Body { get; set; }
        public ChangeUserPasswordSpecification(ChangeUserPasswordCommand command)
        {
            Criteria = u => string.Equals(u.PublicId, command.Id);
            Body = command.Body;
            AddInclude(x => x.Role);
        }
    }
}

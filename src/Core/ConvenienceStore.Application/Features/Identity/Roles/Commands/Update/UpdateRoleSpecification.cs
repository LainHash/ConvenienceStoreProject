using ConvenienceStore.Contract.DTOs.Identity.Roles;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Update
{
    public class UpdateRoleSpecification
        : BaseSpecification<Role>
    {
        public UpdateRoleRequest Body { get; set; }

        public UpdateRoleSpecification(UpdateRoleCommand command)
        {
            Criteria = r => string.Equals(r.PublicId, command.Id);
            Body = command.Body;
        }
    }
}

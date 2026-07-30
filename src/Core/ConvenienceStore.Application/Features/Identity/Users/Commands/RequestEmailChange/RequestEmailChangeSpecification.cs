using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange
{
    public class RequestEmailChangeSpecification : BaseSpecification<User>
    {
        public string NewEmail { get; }

        public RequestEmailChangeSpecification(RequestEmailChangeCommand command)
        {
            Criteria = u => string.Equals(u.PublicId, command.UserId);
            NewEmail = command.Body.NewEmail;
        }
    }
}

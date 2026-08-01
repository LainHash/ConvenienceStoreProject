using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange
{
    public class ConfirmEmailChangeSpecification : BaseSpecification<User>
    {
        public string VerificationCode { get; }

        public ConfirmEmailChangeSpecification(ConfirmEmailChangeCommand command)
        {
            Criteria = u => string.Equals(u.PublicId, command.UserId);
            VerificationCode = command.Body.VerificationCode;
        }
    }
}

using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange
{
    public class ConfirmCurrentEmailChangeSpecification : BaseSpecification<User>
    {
        public string VerificationCode { get; }

        public ConfirmCurrentEmailChangeSpecification(ConfirmCurrentEmailChangeCommand command)
        {
            Criteria = u => string.Equals(u.PublicId, command.UserId);
            VerificationCode = command.Body.VerificationCode;
        }
    }
}

using FluentValidation;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange
{
    public class ConfirmEmailChangeValidator : AbstractValidator<ConfirmEmailChangeCommand>
    {
        public ConfirmEmailChangeValidator()
        {
            RuleFor(x => x.Body.VerificationCode)
                .NotEmpty().WithMessage("Verification code is required.");
        }
    }
}

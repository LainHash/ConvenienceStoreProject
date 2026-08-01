using FluentValidation;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange
{
    public class ConfirmCurrentEmailChangeValidator : AbstractValidator<ConfirmCurrentEmailChangeCommand>
    {
        public ConfirmCurrentEmailChangeValidator()
        {
            RuleFor(x => x.Body.VerificationCode)
                .NotEmpty().WithMessage("Verification code is required.");
        }
    }
}

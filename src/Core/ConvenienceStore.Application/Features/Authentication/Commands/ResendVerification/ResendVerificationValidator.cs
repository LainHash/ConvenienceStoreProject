using FluentValidation;

namespace ConvenienceStore.Application.Features.Authentication.Commands.ResendVerification
{
    public class ResendVerificationValidator
        : AbstractValidator<ResendVerificationCommand>
    {
        public ResendVerificationValidator()
        {
            RuleFor(x => x.Body.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");
        }
    }
}

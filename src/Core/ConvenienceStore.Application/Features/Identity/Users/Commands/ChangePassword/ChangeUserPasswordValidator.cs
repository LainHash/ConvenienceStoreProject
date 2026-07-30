using FluentValidation;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ChangePassword
{
    public class ChangeUserPasswordValidator
        : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordValidator()
        {
            RuleFor(x => x.Body.CurrentPassword)
                .NotEmpty().WithMessage("Current Password is required.");

            RuleFor(x => x.Body.NewPassword)
                .NotEmpty().WithMessage("New Password is required.")
                .MinimumLength(6).WithMessage("New Password must be at least 6 characters.")
                .NotEqual(x => x.Body.CurrentPassword).WithMessage("The new password must be different from your current password.");

            RuleFor(x => x.Body.ConfirmNewPassword)
                .NotEmpty().WithMessage("Confirm New Password is required.")
                .Equal(x => x.Body.NewPassword).WithMessage("Confirm New Password must match the Password.");
        }
    }
}

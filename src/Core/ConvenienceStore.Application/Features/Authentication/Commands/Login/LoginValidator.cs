using FluentValidation;

namespace ConvenienceStore.Application.Features.Authentication.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Body.Email)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Body.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}

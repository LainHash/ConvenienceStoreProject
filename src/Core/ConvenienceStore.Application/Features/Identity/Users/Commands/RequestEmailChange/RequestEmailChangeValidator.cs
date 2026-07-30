using FluentValidation;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange
{
    public class RequestEmailChangeValidator : AbstractValidator<RequestEmailChangeCommand>
    {
        public RequestEmailChangeValidator()
        {
            RuleFor(x => x.Body.NewEmail)
                .NotEmpty().WithMessage("New email is required.")
                .EmailAddress().WithMessage("New email is not a valid email address.");
        }
    }
}

using FluentValidation;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.Update
{
    public class UpdateUserValidator
        : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Body.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters.");
        }
    }
}

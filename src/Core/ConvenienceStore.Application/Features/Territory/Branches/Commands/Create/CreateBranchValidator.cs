using FluentValidation;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Create
{
    public class CreateBranchValidator
        : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator()
        {
            RuleFor(x => x.Body.Country)
                        .NotEmpty().WithMessage("Country is required.")
                        .MaximumLength(100).WithMessage("Country must not exceed 100 characters.");

            RuleFor(x => x.Body.City)
                        .NotEmpty().WithMessage("City is required.")
                        .MaximumLength(100).WithMessage("City must not exceed 100 characters.");
            
            RuleFor(x => x.Body.Address)
                        .NotEmpty().WithMessage("Address is required.")
                        .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Body.Description));
        }
    }
}

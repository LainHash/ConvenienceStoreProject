using FluentValidation;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Create
{
    public class CreateProductValidator
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Body.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.")
                .When(x => !string.IsNullOrEmpty(x.Body.Description));

            RuleFor(x => x.Body.UnitPrice)
                .NotEmpty().WithMessage("Unit price is required.");

            RuleFor(x => x.Body.Unit)
                .NotEmpty().WithMessage("Unit is required.");
        }
    }
}

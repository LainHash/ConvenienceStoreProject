using FluentValidation;

namespace ConvenienceStore.Application.Features.Catalog.Products.Commands.Update
{
    public class UpdateProductValidator
        : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Body.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.")
                .When(x => !string.IsNullOrEmpty(x.Body.Description));
        }
    }
}

using FluentValidation;

namespace ConvenienceStore.Application.Features.Pricing.Discounts.Commands.Create
{
    public class CreateDiscountValidator
        : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountValidator()
        {

        }
    }
}

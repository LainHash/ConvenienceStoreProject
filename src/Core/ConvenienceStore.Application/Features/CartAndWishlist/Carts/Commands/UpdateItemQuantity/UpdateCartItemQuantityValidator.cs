using FluentValidation;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity
{
    public class UpdateCartItemQuantityValidator
        : AbstractValidator<UpdateCartItemQuantityCommand>
    {
        public UpdateCartItemQuantityValidator()
        {
            RuleFor(x => x.Body.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be greater or equal to 0.");
        }
    }
}

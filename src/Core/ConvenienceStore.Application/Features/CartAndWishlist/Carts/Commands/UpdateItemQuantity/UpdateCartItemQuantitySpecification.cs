using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity
{
    public class UpdateCartItemQuantitySpecification
        : BaseSpecification<Cart>
    {
        public string CartItemId { get; set; }
        public UpdateCartItemQuantityRequest Body { get; set; }
        public UpdateCartItemQuantitySpecification(UpdateCartItemQuantityCommand command)
        {
            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                        .ThenInclude((CartItem ci) => ci.Product)
                                        .ThenInclude((Product p) => p.ProductStocks));
            Body = command.Body;
            CartItemId = command.CartItemId;
            Criteria = c => c.CartItems.Any(x => string.Equals(x.PublicId, command.CartItemId));
        }
    }
}

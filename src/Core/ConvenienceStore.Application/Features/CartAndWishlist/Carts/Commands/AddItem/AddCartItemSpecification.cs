using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem
{
    public class AddCartItemSpecification
        : BaseSpecification<Cart>
    {
        public string CustomerId { get; set; } = string.Empty;
        public AddCartItemRequest Body { get; set; }
        public AddCartItemSpecification(AddCartItemCommand command)
        {
            AddInclude(x => x.Customer);
            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                        .ThenInclude((CartItem ci) => ci.Product)
                                        .ThenInclude((Product p) => p.ProductStock));

            Criteria = c => string.Equals(c.Customer.PublicId, command.CustomerId);
            Body = command.Body;
            CustomerId = command.CustomerId;
        }
    }
}

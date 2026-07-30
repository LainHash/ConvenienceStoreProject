using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Commands.AddItem
{
    public class AddWishlistItemSpecification
        : BaseSpecification<Wishlist>
    {
        public AddWishlistItemRequest Body { get; set; }
        public AddWishlistItemSpecification(AddWishlistItemCommand command)
        {
            AddIncludeAggregator(x => x.Include(c => c.WishlistItems)
                                        .ThenInclude((WishlistItem ci) => ci.Product)
                                        .ThenInclude((Product p) => p.ProductStock));

            Body = command.Body;
        }

        public void ApplyCriteria(int id)
        {
            Criteria = c => c.Id == id;
        }
    }
}

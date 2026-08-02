using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId
{
    public class GetWishlistByCustomerIdSpecification
        : BaseSpecification<Wishlist>
    {
        public string UserId { get; set; }

        public GetWishlistByCustomerIdSpecification(GetWishlistByCustomerIdQuery query)
        {
            AddInclude(x => x.Customer);
            AddIncludeAggregator(x => x.Include(w => w.WishlistItems)
                                        .ThenInclude((WishlistItem wi) => wi.Product)
                                        .ThenInclude((Product p) => p.ProductStocks));
            UserId = query.UserId;
        }
    }
}

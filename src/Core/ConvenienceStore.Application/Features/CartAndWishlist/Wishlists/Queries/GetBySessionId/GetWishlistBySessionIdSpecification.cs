using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId
{
    public class GetWishlistBySessionIdSpecification
        : BaseSpecification<Wishlist>
    {
        public string SessionId { get; set; }

        public GetWishlistBySessionIdSpecification(GetWishlistBySessionIdQuery query)
        {
            AddIncludeAggregator(x => x.Include(w => w.WishlistItems)
                                        .ThenInclude((WishlistItem wi) => wi.Product)
                                        .ThenInclude((Product p) => p.ProductStock));

            Criteria = w => string.Equals(w.SessionId, query.SessionId);
            SessionId = query.SessionId;
        }
    }
}

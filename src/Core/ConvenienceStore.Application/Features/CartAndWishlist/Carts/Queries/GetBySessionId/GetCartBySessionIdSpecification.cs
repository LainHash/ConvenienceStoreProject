using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId
{
    public class GetCartBySessionIdSpecification
        : BaseSpecification<Cart>
    {
        public string SessionId { get; set; }
        public GetCartBySessionIdSpecification(GetCartBySessionIdQuery query)
        {
            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                        .ThenInclude((CartItem ci) => ci.Product)
                                        .ThenInclude((Product p) => p.ProductStocks));

            Criteria = c => string.Equals(c.SessionId, query.SessionId);
            SessionId = query.SessionId;
        }
    }
}

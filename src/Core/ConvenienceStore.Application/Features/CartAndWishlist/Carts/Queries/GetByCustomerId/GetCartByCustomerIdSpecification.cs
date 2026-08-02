using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId
{
    public class GetCartByCustomerIdSpecification
        : BaseSpecification<Cart>
    {
        public string UserId { get; set; }
        public GetCartByCustomerIdSpecification(GetCartByCustomerIdQuery query)
        {
            AddInclude(x => x.Customer);
            AddIncludeAggregator(x => x.Include(c => c.CartItems)
                                        .ThenInclude((CartItem ci) => ci.Product)
                                        .ThenInclude((Product p) => p.ProductStocks));
            UserId = query.UserId;
        }
    }
}

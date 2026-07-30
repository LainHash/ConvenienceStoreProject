using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists
{
    public class WishlistResponse
    {
        public string Id { get; set; } = string.Empty;

        public ICollection<WishlistItemResponse> WishlistItems { get; set; } = [];
    }

    public class WishlistItemResponse
    {
        public string Id { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }

        public StockStatus StockStatus { get; set; }
    }
}

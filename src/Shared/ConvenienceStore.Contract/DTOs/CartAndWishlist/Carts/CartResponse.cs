using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts
{
    public class CartResponse
    {
        public string Id { get; set; } = string.Empty;

        public decimal TotalPrice { get; set; }

        public ICollection<CartItemResponse> CartItems { get; set; } = [];
    }

    public class CartItemResponse
    {
        public string Id { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public StockStatus StockStatus { get; set; }

    }
}

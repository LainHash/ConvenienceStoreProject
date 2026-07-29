namespace ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts
{
    public class AddCartItemRequest
    {
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
        public string ProductId { get; set; } = string.Empty;
    }
}

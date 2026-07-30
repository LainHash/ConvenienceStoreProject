namespace ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists
{
    public class AddWishlistItemRequest
    {
        public string? UserId { get; set; }
        public string? SessionId { get; set; }
        public string ProductId { get; set; } = string.Empty;
    }
}

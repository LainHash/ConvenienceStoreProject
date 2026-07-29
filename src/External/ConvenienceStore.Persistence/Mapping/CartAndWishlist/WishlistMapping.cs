using AutoMapper;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Persistence.Mapping.CartAndWishlist
{
    internal class WishlistMapping : Profile
    {
        public WishlistMapping()
        {
            CreateMap<Wishlist, WishlistResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.WishlistItems, opt => opt.MapFrom(src => src.WishlistItems));
        }
    }
}

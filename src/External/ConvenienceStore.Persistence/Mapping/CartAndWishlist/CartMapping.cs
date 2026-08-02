using AutoMapper;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Persistence.Mapping.CartAndWishlist
{
    internal class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, CartResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.CartItems.Sum(x => x.Quantity * x.Product.ProductPrice.UnitPrice)));
        }
    }
}

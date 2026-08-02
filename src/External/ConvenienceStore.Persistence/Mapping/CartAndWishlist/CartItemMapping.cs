using AutoMapper;
using ConvenienceStore.Application.Extensions;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Persistence.Mapping.CartAndWishlist
{
    internal class CartItemMapping : Profile
    {
        public CartItemMapping()
        {
            CreateMap<CartItem, CartItemResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.ProductPrice.UnitPrice))
                .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.Product.ProductPrice.UnitPrice * src.Quantity));
        }
    }
}

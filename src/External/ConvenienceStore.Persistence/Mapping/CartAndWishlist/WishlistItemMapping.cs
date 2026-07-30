using AutoMapper;
using ConvenienceStore.Application.Extensions;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Persistence.Mapping.CartAndWishlist
{
    internal class WishlistItemMapping : Profile
    {
        public WishlistItemMapping()
        {
            CreateMap<WishlistItem, WishlistItemResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.ProductStock.UnitPrice))
                .ForMember(dest => dest.StockStatus, opt => opt.MapFrom(src => src.Product.ProductStock.QuantityOnHand.ToStockStatus()));
        }
    }
}

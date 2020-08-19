using AutoMapper;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.API.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(dto => dto.Name, conf => conf.MapFrom(ci => ci.Item.Name))
                .ForMember(dto => dto.Id, conf => conf.MapFrom(ci => ci.Item.Id))
                .ForMember(dto => dto.Price, conf => conf.MapFrom(ci => ci.Item.Price))
                .ForMember(dto => dto.Quantity, conf => conf.Ignore());

            CreateMap<CartDiscount, CartDiscountDTO>()
                .ForMember(dto => dto.Code, conf => conf.MapFrom(cd => cd.Discount.Code))
                .ForMember(dto => dto.Percentage, conf => conf.MapFrom(cd => cd.Discount.Percentage));
        }
    }
}

using AutoMapper;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.API.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>();
        }
    }
}

using AutoMapper;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, CartItemsCreateDTO>();
        }
    }
}

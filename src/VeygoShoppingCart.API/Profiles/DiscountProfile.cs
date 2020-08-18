using AutoMapper;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.API.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, DiscountsCreateDTO>();
            CreateMap<Discount, DiscountsReadDTO>();
        }
    }
}

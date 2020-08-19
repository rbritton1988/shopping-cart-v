using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.API.Helpers
{
    public static class ShoppingCartMapper
    {
        public static ShoppingCartDTO MapCartDomainCartToDTO(ShoppingCart cart, IMapper mapper)
        {
            var mapped_cart = new ShoppingCartDTO
            {
                CartId = cart.Id,
                Discounts = mapper.Map<ICollection<CartDiscountDTO>>(cart.CartDiscounts),
                Items = mapper.Map<ICollection<CartItemDTO>>(cart.CartItems),
                TotalPrice = cart.TotalPrice
            };

            for (int i = 0; i < mapped_cart.Items.Count(); i++)
            {
                var item = cart.CartItems.First(ci => ci.ItemId == mapped_cart.Items.ElementAt(i).Id);
                mapped_cart.Items.ElementAt(i).Quantity = item.Quantity;
            }

            return mapped_cart;
        }
    }
}
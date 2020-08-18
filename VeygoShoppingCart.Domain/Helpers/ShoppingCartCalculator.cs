using System.Collections.Generic;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.Domain.Helpers
{
    public static class ShoppingCartCalculator
    {
        public static decimal CalucalateTotalPrice(List<CartItem> cartItems, List<CartDiscount> cartDiscounts)
        {
            var total = 0.00M;

            cartItems.ForEach(cartItem =>
            {
                total += cartItem.Item.Price * cartItem.Quantity;
            });

            cartDiscounts.ForEach(cartDiscount =>
            {
                total *= (decimal)cartDiscount.Discount.Percentage;
            });

            return total;
        }
    }
}

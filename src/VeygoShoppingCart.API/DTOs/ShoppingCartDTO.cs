using System.Collections.Generic;


namespace VeygoShoppingCart.API.DTOs
{
    public class ShoppingCartDTO
    {
        public IEnumerable<CartItemsCreateDTO> Items { get; set; }
        public IEnumerable<DiscountsCreateDTO> Discounts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

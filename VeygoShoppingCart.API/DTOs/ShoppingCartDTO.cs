using System.Collections.Generic;


namespace VeygoShoppingCart.API.DTOs
{
    public class ShoppingCartDTO
    {
        public List<ItemDTO> Items { get; set; }
        public List<DiscountDTO> Discounts { get; set; }
        public double TotalPrice { get; set; }
    }
}

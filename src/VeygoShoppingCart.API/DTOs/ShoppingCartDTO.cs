using System.Collections.Generic;


namespace VeygoShoppingCart.API.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class DiscountDTO
    {
        public string Code { get; set; }
        public double Percentage { get; set; }
    }

    public class ShoppingCartDTO
    {
        public int CartId { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
        public ICollection<DiscountDTO> Discounts { get; set; }
    }
}

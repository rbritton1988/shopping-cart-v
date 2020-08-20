using System.Collections.Generic;


namespace VeygoShoppingCart.API.DTOs
{

    public class ShoppingCartDTO
    {
<<<<<<< HEAD
        public int Id { get; set; }
=======
>>>>>>> develop
        public int CartId { get; set; }
        public ICollection<CartItemDTO> Items { get; set; }
        public ICollection<CartDiscountDTO> Discounts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

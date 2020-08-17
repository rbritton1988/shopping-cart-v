using System.Collections.Generic;


namespace VeygoShoppingCart.Domain.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<CartDiscount> CartDiscounts { get; set; }
        public bool Complete { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

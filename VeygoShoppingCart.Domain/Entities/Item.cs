using System.Collections.Generic;


namespace VeygoShoppingCart.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        virtual public ICollection<CartItem> CartItems { get; set; }
    }
}

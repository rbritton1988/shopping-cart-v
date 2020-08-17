using System.Collections;
using System.Collections.Generic;
using VeygoShoppingCart.Domain.Entities;

namespace VeygoShoppingCart.Domain.Models
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

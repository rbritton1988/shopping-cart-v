using System.Collections.Generic;
using VeygoShoppingCart.Domain.Entities;

namespace VeygoShoppingCart.Domain.Models
{
    public class Discount : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Percentage { get; set; }
        public string Description { get; set; }
        public ICollection<CartDiscount> CartDiscounts { get; set; }
    }
}

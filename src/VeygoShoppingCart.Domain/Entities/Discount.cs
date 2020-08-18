using System.Collections.Generic;


namespace VeygoShoppingCart.Domain.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Percentage { get; set; }
        public string Description { get; set; }
        virtual public ICollection<CartDiscount> CartDiscounts { get; set; }
    }
}

namespace VeygoShoppingCart.Domain.Models
{
    public class CartDiscount
    {
        public int ShoppingCartId { get; set; }
        virtual public ShoppingCart ShoppingCart { get; set; }
        public int DiscountId { get; set; }
        virtual public Discount Discount { get; set; }
    }
}

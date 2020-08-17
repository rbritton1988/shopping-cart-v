namespace VeygoShoppingCart.Domain.Models
{
    public class CartDiscount
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int DiscountId { get; set; }
        virtual public Discount Discount { get; set; }
    }
}

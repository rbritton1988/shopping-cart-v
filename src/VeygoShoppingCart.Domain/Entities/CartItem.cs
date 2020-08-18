namespace VeygoShoppingCart.Domain.Models
{
    public class CartItem
    {
        public int ShoppingCartId { get; set; }
        virtual public ShoppingCart ShoppingCart { get; set; }
        public int ItemId { get; set; }
        virtual public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}

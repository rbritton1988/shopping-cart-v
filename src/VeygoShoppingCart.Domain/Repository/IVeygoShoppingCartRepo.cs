using System.Collections.Generic;
using VeygoShoppingCart.Domain.Models;


namespace VeygoShoppingCart.Domain.Repository
{
    public interface IVeygoShoppingCartRepo
    {
        public IEnumerable<Item> GetAllItems();
        public IEnumerable<Discount> GetAllDiscounts();
        public Discount GetDiscountById(int id);
        public int CreateShoppingCart();
        public ShoppingCart AddItemToShoppingCart(int cart_id, int item_id);
        public ShoppingCart UpdateShoppingCartItemQuantity(int cart_id, int item_id);
        public ShoppingCart AddShoppingCartDiscount(int cart_id, string code);
        public ShoppingCart RemoveShoppingCartDiscount(int cart_id, string code);
    }
}

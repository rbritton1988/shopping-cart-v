using System.Collections.Generic;
using VeygoShoppingCart.Domain.Models;


namespace VeygoShoppingCart.Domain.Repository
{
    public interface IVeygoShoppingCartRepo
    {
        public IEnumerable<Item> GetAllItems();
        public Item GetItemById(int item_id);

        public IEnumerable<Discount> GetAllDiscounts();
        public Discount GetDiscountById(int id);
        public Discount GetDiscountByCode(string discount_code);

        public bool DiscountExistsInShoppingCart(int cart_id, string discount_code);

        public IEnumerable<CartItem> GetCartItemsByCartId(int cart_id);
        public CartItem GetCartItemById(int id);

        public IEnumerable<CartDiscount> GetCartDiscountsByCartId(int cart_id);
        public CartDiscount GetCartDiscountById(int id);

        public ShoppingCart CreateShoppingCart();
        public ShoppingCart GetShoppingCartById(int id);        
        public ShoppingCart AddItemToShoppingCart(int cart_id, int item_id);
        public ShoppingCart UpdateShoppingCartItemQuantity(int cart_id, int item_id);
        public ShoppingCart AddShoppingCartDiscount(int cart_id, string code);
        public ShoppingCart RemoveShoppingCartDiscount(int cart_id, string code);
        
    }
}

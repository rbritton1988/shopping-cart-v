using System.Collections.Generic;
using VeygoShoppingCart.Domain.Models;


namespace VeygoShoppingCart.Domain.Repository
{
    public interface IVeygoShoppingCartRepo
    {
        public IEnumerable<Item> GetAllItems();
        public IEnumerable<Discount> GetAllDiscounts();
        public Discount GetDiscountByCode(string discount_code);
        public Item GetItemById(int item_id);
        public bool DiscountExistsInShoppingCart(int cart_id, string discount_code);
        public void ReduceShoppingCartItemQuantity(int cart_id, int item_id);
        public void IncreaseShoppingCartItemQuantity(int cart_id, int item_id);
        public void ClearShoppingCartItems(int cart_id);
        public ShoppingCart CreateShoppingCart();
        public ShoppingCart GetShoppingCartById(int id);        
        public void AddShoppingCartDiscount(ShoppingCart cart, Discount discount);
        public void UpdateShoppingCartTotalPrice(int cart_id);
        public void CheckoutShoppingCart(ShoppingCart cart);
    }
}

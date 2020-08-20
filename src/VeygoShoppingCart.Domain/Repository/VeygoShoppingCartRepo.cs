using System.Collections.Generic;
using System.Linq;
using VeygoShoppingCart.Domain.Helpers;
using VeygoShoppingCart.Domain.Models;

namespace VeygoShoppingCart.Domain.Repository
{
    public class VeygoShoppingCartRepo : IVeygoShoppingCartRepo
    {
        private readonly EFCoreContext _context;

        public VeygoShoppingCartRepo(EFCoreContext context)
        {
            _context = context;
        }

        public void IncreaseShoppingCartItemQuantity(int cart_id, int item_id)
        {
            var existing_item = _context.ShoppingCartItems.FirstOrDefault(si => si.ShoppingCartId == cart_id && si.ItemId == item_id);

            if (existing_item != null)
            {
                existing_item.Quantity += 1;
                Save();
            }
            else
            {
                var shopping_cart = _context.ShoppingCarts.FirstOrDefault(sc => sc.Id == cart_id);
                var item = _context.Items.FirstOrDefault(i => i.Id == item_id);

                var new_cart_item = new CartItem
                {
                    ItemId = item_id,
                    Item = item,
                    ShoppingCartId = cart_id,
                    ShoppingCart = shopping_cart,
                    Quantity = 1
                };

                _context.ShoppingCartItems.Add(new_cart_item);
                Save();
            }
        }

        public void ReduceShoppingCartItemQuantity(int cart_id, int item_id)
        {
            var cart_item = _context.ShoppingCartItems.FirstOrDefault(si => si.ShoppingCartId == cart_id && si.ItemId == item_id);
            if (cart_item == null) return;

            cart_item.Quantity -= 1;

            if (cart_item.Quantity <= 0)
            {
                _context.ShoppingCartItems.Remove(cart_item);
            }
            else
            {
                _context.ShoppingCartItems.Update(cart_item);
            }

            Save();
        }

        public void AddShoppingCartDiscount(ShoppingCart cart, Discount discount)
        {
            var cart_discount = new CartDiscount { 
                DiscountId = discount.Id, 
                ShoppingCartId = cart.Id,
                Discount = discount,
                ShoppingCart = cart
            };

            _context.ShoppingCartDiscounts.Add(cart_discount);

            Save();
        }

        public void ClearShoppingCartItems(int cart_id)
        {
            var cart_items = _context.ShoppingCartItems.Where(si => si.ShoppingCartId == cart_id).ToList();
            _context.ShoppingCartItems.RemoveRange(cart_items);
            Save();
        }

        public ShoppingCart CreateShoppingCart()
        {
            var new_cart = new ShoppingCart();
            _context.ShoppingCarts.Add(new_cart);
            Save();
            return new_cart;
        }

        public bool DiscountExistsInShoppingCart(int cart_id, string discount_code)
        {
            var cartDiscount = _context.ShoppingCartDiscounts
                .FirstOrDefault(scd => scd.ShoppingCartId == cart_id && scd.Discount.Code == discount_code);
            return cartDiscount != null;
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            return _context.Discounts;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items;
        }

        public Discount GetDiscountByCode(string discount_code)
        {
            return _context.Discounts.FirstOrDefault(d => d.Code == discount_code);
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            return _context.ShoppingCarts.FirstOrDefault(sc => sc.Id == id);
        }

        public Item GetItemById(int item_id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == item_id);
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateShoppingCartTotalPrice(int cart_id)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.Id == cart_id);
            var price = ShoppingCartCalculator.CalucalateTotalPrice(shoppingCart.CartItems.ToList(), shoppingCart.CartDiscounts.ToList());
            shoppingCart.TotalPrice = price;
            Save();
        }
<<<<<<< HEAD
=======

        public void CheckoutShoppingCart(ShoppingCart cart)
        {
            cart.Complete = true;
            _context.ShoppingCarts.Update(cart);
            Save();
        }
>>>>>>> develop
    }
}

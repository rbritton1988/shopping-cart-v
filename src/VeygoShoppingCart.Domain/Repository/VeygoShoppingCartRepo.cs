using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddItemToShoppingCart(int cart_id, int item_id)
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

        public ShoppingCart AddShoppingCartDiscount(int cart_id, string code)
        {
            bool discount_exists = DiscountExistsInShoppingCart(cart_id, code);
            if (discount_exists)
            {
                throw new ArgumentException("Discount already applied to that cart");
            }
            var cart_discount = new CartDiscount { DiscountId = 1, ShoppingCartId = cart_id };
            _context.ShoppingCartDiscounts.Add(cart_discount);
            Save();
            return cart_discount.ShoppingCart;
        }

        public void ClearCartItems(int cart_id)
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

        public CartDiscount GetCartDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartDiscount> GetCartDiscountsByCartId(int cart_id)
        {
            return _context.ShoppingCartDiscounts.Where(sd => sd.ShoppingCartId == cart_id);
        }

        public CartItem GetCartItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetCartItemsByCartId(int cart_id)
        {
            return _context.ShoppingCartItems.Where(si => si.ShoppingCartId == cart_id);
        }

        public Discount GetDiscountByCode(string discount_code)
        {
            throw new NotImplementedException();
        }

        public Discount GetDiscountById(int id)
        {
            return _context.Discounts.Where(i => i.Id == id).FirstOrDefault();
        }

        public Item GetItemById(int item_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItemsByCartId(int cart_id)
        {
            var items = new List<Item>() { };
            _context.ShoppingCartItems.Where(si => si.ShoppingCartId == cart_id)?.ToList().ForEach(ci =>
            {
                items.Append(_context.Items.FirstOrDefault(i => i.Id == ci.ItemId));
            });

            return items;
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            var cart = _context.ShoppingCarts.FirstOrDefault(sc => sc.Id == id);

            var c = new ShoppingCart
            {
                Id = cart.Id,
                CartDiscounts = cart.CartDiscounts.ToList(),
                CartItems = cart.CartItems.ToList(),
                Complete = cart.Complete
            };

            return c;
        }

        public void ReduceCartItemQuantity(int cart_id, int item_id)
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

        public ShoppingCart RemoveShoppingCartDiscount(int cart_id, string code)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart UpdateShoppingCartItemQuantity(int cart_id, int item_id)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _context.SaveChanges();
        }

    }
}

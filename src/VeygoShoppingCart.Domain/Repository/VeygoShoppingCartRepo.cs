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

        public ShoppingCart AddItemToShoppingCart(int cart_id, int item_id)
        {
            throw new NotImplementedException();
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
            _context.SaveChanges();
            return cart_discount.ShoppingCart;
        }

        public ShoppingCart CreateShoppingCart()
        {
            var new_cart = new ShoppingCart();
            _context.ShoppingCarts.Add(new_cart);
            _context.SaveChanges();
            return new_cart;
        }

        public bool DiscountExistsInShoppingCart(int cart_id, string discount_code)
        {
            var cartDiscount = _context.ShoppingCartDiscounts.FirstOrDefault(scd => scd.ShoppingCartId == cart_id && scd.Discount.Code == discount_code);
            return cartDiscount != null;
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
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

        public ShoppingCart GetShoppingCartById(int id)
        {

            return _context.ShoppingCarts.FirstOrDefault(sc => sc.Id == id);
        }

        public ShoppingCart RemoveShoppingCartDiscount(int cart_id, string code)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart UpdateShoppingCartItemQuantity(int cart_id, int item_id)
        {
            throw new NotImplementedException();
        }

    }
}

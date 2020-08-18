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
            throw new NotImplementedException();
        }

        public int CreateShoppingCart()
        {
            var new_cart = new ShoppingCart();
            _context.ShoppingCarts.Add(new_cart);
            _context.SaveChanges();
            return new_cart.Id;
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Discount GetDiscountById(int id)
        {
            return _context.Discounts.Where(i => i.Id == id).FirstOrDefault();
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

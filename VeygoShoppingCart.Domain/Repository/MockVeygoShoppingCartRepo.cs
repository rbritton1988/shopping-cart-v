using System;
using System.Collections.Generic;
using System.Linq;
using VeygoShoppingCart.Domain.Models;


namespace VeygoShoppingCart.Domain.Repository
{
    public class MockVeygoShoppingCartRepo : IVeygoShoppingCartRepo
    {
        private List<Discount> _discounts;
        private List<ShoppingCart> _shoppingCart;

        public MockVeygoShoppingCartRepo()
        {
            CreateDiscounts();
            CreateShoppingCarts();
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
            throw new NotImplementedException();
        }

        public Item GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Discount GetDiscountById(int id)
        {
            var discount = _discounts.FirstOrDefault(x => x.Id == id);
            return discount;
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            return _discounts;
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart RemoveShoppingCartDiscount(int cart_id, string code)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart UpdateShoppingCartItemQuantity(int cart_id, int item_id)
        {
            throw new NotImplementedException();
        }

        private void CreateDiscounts()
        {
            _discounts = new List<Discount>
            {
                new Discount { Id = 1, Code = "S4V3R05", Description = "Save 5% on your order.", Percentage = 0.05 },
                new Discount { Id = 2, Code = "BIGD3AL", Description = "Save 25% on your order.", Percentage = 0.25 },
                new Discount { Id = 3, Code = "SUMM3R20", Description = "Save 20% on your order.", Percentage = 0.20 }
            };
        }

        private void CreateShoppingCartItems()
        {

        }

        private void CreateShoppingCartDiscounts()
        {

        }


        private void CreateShoppingCarts()
        {
            _shoppingCart = new List<ShoppingCart>
            {
                new ShoppingCart{ Id = 1, TotalPrice = 0.00M, Complete = false },
                new ShoppingCart{ Id = 2, TotalPrice = 0.00M, Complete = false },
                new ShoppingCart{ Id = 3, TotalPrice = 0.00M, Complete = false }
            };
        }
    }
}

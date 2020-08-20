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

        public void IncreaseShoppingCartItemQuantity(int cart_id, int item_id)
        {
            throw new NotImplementedException();
        }

        public void AddShoppingCartDiscount(ShoppingCart cart, Discount discount)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart CreateShoppingCart()
        {
            throw new NotImplementedException();
        }


        public Discount GetDiscountById(int id)
        {
            var discount = _discounts.FirstOrDefault(x => x.Id == id);
            return discount;
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
            throw new NotImplementedException();
        }

        private void CreateShoppingCartDiscounts()
        {
            throw new NotImplementedException();
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

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            throw new NotImplementedException();
        }

        public bool DiscountExistsInShoppingCart(int cart_id, string discount_code)
<<<<<<< HEAD
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetShoppingCartById(int id)
=======
>>>>>>> develop
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Discount GetDiscountByCode(string discount_code)
=======
        public ShoppingCart GetShoppingCartById(int id)
>>>>>>> develop
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public void ClearShoppingCartItems(int cart_id)
=======
        public Discount GetDiscountByCode(string discount_code)
>>>>>>> develop
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public void ReduceShoppingCartItemQuantity(int cart_id, int item_id)
=======
        public void ClearShoppingCartItems(int cart_id)
>>>>>>> develop
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Item GetItemById(int item_id)
=======
        public void ReduceShoppingCartItemQuantity(int cart_id, int item_id)
>>>>>>> develop
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public void UpdateShoppingCartTotalPrice(int cart_id)
        {
            throw new NotImplementedException();
=======
        public Item GetItemById(int item_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateShoppingCartTotalPrice(int cart_id)
        {
            throw new NotImplementedException();
        }

        public void CheckoutShoppingCart(ShoppingCart cart)
        {
            throw new NotImplementedException();
>>>>>>> develop
        }
    }
}

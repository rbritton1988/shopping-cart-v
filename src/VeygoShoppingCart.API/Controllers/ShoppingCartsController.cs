using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;
using VeygoShoppingCart.Domain.Repository;


namespace VeygoShoppingCart.API.Controllers
{
    [Route("api/shopping-carts")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IVeygoShoppingCartRepo _repo;
        private readonly IMapper _mapper;

        public ShoppingCartsController(IVeygoShoppingCartRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{cart_id}")]
        public ActionResult<ShoppingCart> GetShoppingCart(int cart_id)
        {
            var cart = _repo.GetShoppingCartById(cart_id);

            var mapped_cart = new ShoppingCartDTO();
            mapped_cart.CartId = cart.Id;
            mapped_cart.Discounts = _mapper.Map<ICollection<DiscountDTO>>(cart.CartDiscounts);
            mapped_cart.Items = _mapper.Map<ICollection<ItemDTO>>(cart.CartItems);

            for (int i = 0; i < mapped_cart.Items.Count(); i++)
            {
                var item = cart.CartItems.First(ci => ci.ItemId == mapped_cart.Items.ElementAt(i).Id);
                mapped_cart.Items.ElementAt(i).Quantity = item.Quantity;
            }

            return Ok(mapped_cart);
        }

        [HttpPost]
        public ActionResult<ShoppingCartDTO> CreateShoppingCart()
        {
            var new_cart = _repo.CreateShoppingCart();
            return Ok(new_cart);
        }

        [HttpPost("{cart_id}/items/{item_id}")]
        public ActionResult<CartItemsCreateDTO> AddItemToShoppingCart(int cart_id, int item_id)
        {
            _repo.AddItemToShoppingCart(cart_id, item_id);

            // Return the Shopping Cart


            return Ok(new CartItemsCreateDTO());
        }

        [HttpDelete("{cart_id}/items/{item_id}")]
        public ActionResult<ShoppingCartDTO> RemoveItemFromShoppingCart(int cart_id, int item_id)
        {
            _repo.ReduceCartItemQuantity(cart_id, item_id);
            return Ok(new ShoppingCartDTO());
        }

        [HttpDelete("{cart_id}/items")]
        public ActionResult<ShoppingCartDTO> ClearShoppingCartItems(int cart_id)
        {
            _repo.ClearCartItems(cart_id);
            return Ok(new ShoppingCartDTO());
        }

        [HttpPost("{cart_id}/discounts/{discount_code}")]
        public ActionResult<ShoppingCartDTO> AddDiscountToShoppingCart(int cart_id, string discount_code)
        {
            var cart = _repo.AddShoppingCartDiscount(cart_id, discount_code);
            return Ok(cart);
        }

        [HttpPost("{cart_id}/checkout")]
        public ActionResult<ShoppingCartDTO> CheckoutShoppingCart(int cart_id)
        {
            // Set cart to complete.
            return Ok(new ShoppingCartDTO());
        }

    }
}

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
        public ActionResult<ShoppingCartDTO> GetShoppingCart(int cart_id)
        {
            var cart_items = _repo.GetCartItemsByCartId(cart_id).ToList();
            var cart_discounts = _repo.GetCartDiscountsByCartId(cart_id).ToList();            
            var mapped_cart = new ShoppingCartDTO();

            cart_items.ForEach(ci => mapped_cart.Items.Append(_mapper.Map<CartItemsCreateDTO>(ci.Item)));
            cart_discounts.ForEach(cd => mapped_cart.Discounts.Append(_mapper.Map<DiscountsCreateDTO>(cd.Discount)));

            return Ok(mapped_cart);
        }

        [HttpPost]
        public ActionResult<ShoppingCartDTO> CreateShoppingCart()
        {
            var new_cart = _repo.CreateShoppingCart();
            return Ok(new_cart);
        }

        [HttpPost("{cart_id}/items")]
        public ActionResult<CartItemsCreateDTO> AddItemToShoppingCart(int cart_id, [FromBody] CartItemsCreateDTO cart_item)
        {
            return Ok(new CartItemsCreateDTO());
        }

        [HttpDelete("{cart_id}/items/{item_id}")]
        public ActionResult<ShoppingCartDTO> RemoveItemQtyToShoppingCart(int cart_id, int item_id)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpDelete("{cart_id}/items")]
        public ActionResult<ShoppingCartDTO> RemoveAllItemsFromShoppingCart(int cart_id)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpPost("{cart_id}/discounts")]
        public ActionResult<ShoppingCartDTO> AddDiscountToShoppingCart(int cart_id, [FromBody] string discount_code)
        {
            var cart = _repo.AddShoppingCartDiscount(cart_id, discount_code);
            return Ok(cart);
        }

        [HttpDelete("{cart_id}/discounts/{discount_code}")]
        public ActionResult<ShoppingCartDTO> RemoveDiscountFromShoppingCart(int cart_id, string discount_code)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpDelete("{cart_id}/discounts")]
        public ActionResult<ShoppingCartDTO> RemoveAllDiscountsFromShoppingCart(int cart_id)
        {
            return Ok(new ShoppingCartDTO());
        }

        // finish cart
        [HttpPost("{cart_id}/checkout")]
        public ActionResult<ShoppingCartDTO> CheckoutShoppingCart(int cart_id)
        {
            return Ok(new ShoppingCartDTO());
        }

    }
}

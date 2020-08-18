using System.Linq;
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

        public ShoppingCartsController(IVeygoShoppingCartRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<ShoppingCartDTO> CreateShoppingCart()
        {
            int cart_id = _repo.CreateShoppingCart();
            return Ok(cart_id);
        }

        [HttpPut("{cart_id}/items/{item_id}/quantity/{qty}")]
        public ActionResult<ShoppingCartDTO> UpdateOrAddCartItemQtyToShoppingCart(int cart_id, int item_id, int qty)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpDelete("{cart_id}/items")]
        public ActionResult<ShoppingCartDTO> RemoveAllItemsFromShoppingCart(int cart_id)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpPost("{cart_id}/discounts/{code}")]
        public ActionResult<ShoppingCartDTO> AddDiscountToShoppingCart(int cart_id, string code)
        {
            return Ok(new ShoppingCartDTO());
        }

        [HttpDelete("{cart_id}/discounts/{discount_id}")]
        public ActionResult<ShoppingCartDTO> RemoveDiscountFromShoppingCart(int cart_id, string code)
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

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.API.Helpers;
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
            var cart = _repo.GetShoppingCartById(cart_id);
            _repo.UpdateShoppingCartTotalPrice(cart_id);

            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(cart, _mapper);
            return Ok(mapped_cart);
        }

        [HttpPost]
        public ActionResult<ShoppingCartDTO> CreateShoppingCart()
        {
            var new_cart = _repo.CreateShoppingCart();
            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(new_cart, _mapper);
            return Ok(mapped_cart);
        }

        [HttpPost("{cart_id}/items/{item_id}")]
        public ActionResult<ShoppingCartDTO> AddItemToShoppingCart(int cart_id, int item_id)
        {
            _repo.IncreaseShoppingCartItemQuantity(cart_id, item_id);
            _repo.UpdateShoppingCartTotalPrice(cart_id);

            var cart = _repo.GetShoppingCartById(cart_id);
            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(cart, _mapper);

            return Ok(mapped_cart);
        }

        [HttpDelete("{cart_id}/items/{item_id}")]
        public ActionResult<ShoppingCartDTO> RemoveItemFromShoppingCart(int cart_id, int item_id)
        {
            _repo.ReduceShoppingCartItemQuantity(cart_id, item_id);
            _repo.UpdateShoppingCartTotalPrice(cart_id);

            var cart = _repo.GetShoppingCartById(cart_id);
            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(cart, _mapper);

            return Ok(mapped_cart);
        }

        [HttpDelete("{cart_id}/items")]
        public ActionResult<ShoppingCartDTO> ClearShoppingCartItems(int cart_id)
        {
            _repo.ClearShoppingCartItems(cart_id);
            _repo.UpdateShoppingCartTotalPrice(cart_id);

            var cart = _repo.GetShoppingCartById(cart_id);
            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(cart, _mapper);

            return Ok(mapped_cart);
        }

        [HttpPost("{cart_id}/discounts/{discount_code}")]
        public ActionResult<ShoppingCartDTO> AddDiscountToShoppingCart(int cart_id, string discount_code)
        {
            var shoppingCart = _repo.GetShoppingCartById(cart_id);
            var discount = _repo.GetDiscountByCode(discount_code);

            bool discount_applied = _repo.DiscountExistsInShoppingCart(cart_id, discount_code);
            
            if (discount_applied)
            {
                return BadRequest();
            }

            _repo.AddShoppingCartDiscount(shoppingCart, discount);
            _repo.UpdateShoppingCartTotalPrice(cart_id);

            var mapped_cart = ShoppingCartMapper.MapCartDomainCartToDTO(shoppingCart, _mapper);

            return Ok(mapped_cart);
        }

        [HttpPost("{cart_id}/checkout")]
        public ActionResult<ShoppingCartDTO> CheckoutShoppingCart(int cart_id)
        {
            // Set cart to complete.
            return Ok(new ShoppingCartDTO());
        }
    }
}

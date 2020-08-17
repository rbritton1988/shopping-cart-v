using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Repository;


namespace VeygoShoppingCart.API.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IVeygoShoppingCartRepo _repo;

        public DiscountsController(IVeygoShoppingCartRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiscountDTO>> GetAllDiscounts()
        {
            var discounts = _repo.GetDiscounts();

            // map domain discount to dto then send

            return Ok(discounts);
        }
    }
}
